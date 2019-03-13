﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statuscalc : MonoBehaviour
{
    float syuzokuchi = 60.0f;
    float level;
    float HP;
    float ABCDS;
    int hp;
    int abcds;

    //使う可能性
    //プレイヤー　エネミー　魔王
    //種族値やレベルが変わる

    public (int,int) CalcStatus(int level)
    {
        HP = this.syuzokuchi * 2.0f * (level / 100.0f) + (10.0f + level);
        hp = (int)HP;
        ABCDS = this.syuzokuchi * 2.0f * (level / 100.0f) + 5.0f;
        abcds = (int)ABCDS;
        return (hp,abcds);
    }

    public (int, int) CalcStatus(int level,int syuzokuti)
    {
        HP = syuzokuchi * 2.0f * (level / 100.0f) + (10.0f + level);
        hp = (int)HP;
        ABCDS = syuzokuchi * 2.0f * (level / 100.0f) + 5.0f;
        abcds = (int)ABCDS;
        return (hp, abcds);
    }


    void Memo()
    {
        float 種族値 = 60;
        float 個体値 = 0;
        float 努力値 = 0;
        //float レベル = 0;
        float HP = 0;
        float ABCDS = 0;
        int hp = 0;
        int abcds = 0;

        //HP
        //HP = (種族値 * 2 + 個体値 + 努力値 / 4) * (レベル / 100) + (10 + レベル);

        //HP以外
        //ABCDS = (種族値 * 2 + 個体値 + 努力値 / 4) * (レベル / 100) + 5;


        for (int i = 1; i < 51; i++)
        {
            HP = (種族値 * 2.0f + 個体値 + (努力値 / 4.0f)) * (i / 100.0f) + (10.0f + i);
            hp = (int)HP;
            ABCDS = (種族値 * 2.0f + 個体値 + 努力値 / 4.0f) * ((float)i / 100.0f) + 5.0f;
            abcds = (int)ABCDS;
            Debug.Log($"レベル{i},{hp},{abcds},{abcds},{abcds},{abcds},{abcds}");
        }
    }
}