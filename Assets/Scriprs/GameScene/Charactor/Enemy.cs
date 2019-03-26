using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charactor, IBattleable
{
    public int level { get; set; }
    public int hp { get; set; }
    public int attackPoint { get; set; }
    public int defencePoint { get; set; }
    public int magicAttackPoint { get; set; }
    public int magicDefencePoint { get; set; }
    public int speed { get; set; }

    void Start()
    {
        charactorName = "敵";
    }

    public void Attack()
    {
        Debug.Log("敵の攻撃！");
    }

    public void BeDamaged(int damagePoint)
    {
        Debug.Log($"敵に{damagePoint}のダメージ");
        hp -= damagePoint;
        Debug.Log($"敵のHPが{hp}になった。");
    }
}
