using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charactor, IAttackable, IDamageable
{
    public void Attack()
    {
        Debug.Log("敵の攻撃！");
    }

    public void BeDamaged()
    {
        Debug.Log($"敵のHPが{hp}になった");
    }
}
