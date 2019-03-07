﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainMassJudger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        //衝突相手がIRollableを持っていなければ何もしない
        var rolling = other.GetComponent<IRollable>();
        if (rolling == null) return;

        //衝突相手がIMoveableを持っていなければ何もしない
        var moving = other.GetComponent<IMoveable>();
        if (moving == null) return;

        //現在のマスと衝突判定していたら、次マスから衝突判定させるようにする
        //if (moving.firstMass)
        //{
        //    moving.firstMass = false;
        //    return;
        //}

        //進む残りマス数を更新
        rolling.remainMass--;
        Debug.Log($"残りマスが{rolling.remainMass}になりました");

        //まだ進む必要があるなら
        if (rolling.remainMass > 0)
        {
            moving.isMoving = true;
        }
        //残りマスが0だったら
        else
        {
            //これ以上動かないようにする
            moving.isMoving = false;
            //マス中央にキャラクターを動かす
            var posX = transform.position.x;
            var posY = other.transform.position.y;
            var posZ = transform.position.z;
            other.transform.position = new Vector3(posX, posY, posZ);
            //次回、現在のマスと衝突判定しないようにする
            //moving.firstMass = true;
        }
    }
}