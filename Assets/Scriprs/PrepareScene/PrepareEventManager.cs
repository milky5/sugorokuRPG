using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareEventManager : MonoBehaviour
{
    //StartButtonが押されたら呼ばれるメソッド
    public void OnStartButtonDown()
    {
        //firstcanvasをdisable
        //nextcanvasをenable
    }

    //DropDownListの値が変わったら呼ばれるメソッド
    public void OnDropDownValueChanged()
    {
        //InputFieldとlabel?を増減させる
    }

    //GOButtonが押されたら呼ばれるメソッド
    public void OnGOButtonDown()
    {
        //staticクラスに何人でプレイするのかと名前を渡し、
        //GameSceneを読み込み
    }
}
