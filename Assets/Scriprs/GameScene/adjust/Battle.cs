using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Battle : MonoBehaviour
{
    //攻撃は物理か魔法か選ばせる
    //攻撃側と防御側を交互に実施
    //攻撃側のAtackと防御側のDefenceの計算をして、防御側のHPを減少させる

}

class Program2 : MonoBehaviour
{
    statuscalc statuscalc;
    Player player;
    Enemy enemy;

    private void Start()
    {
        player.charactorName = "テスターちゃん";
    }

    void Main()
    {
        player.level = 50;
        enemy.level = 50;
        int enemySyuzokuchi = 50;

        //Playerのステータスを取得
        (int playerhp, int playerabcds) = statuscalc.PlayerCalcStatus(player.level);
        player.hp = playerhp;
        player.attackPoint = playerabcds;
        player.defencePoint = playerabcds;
        player.magicAttackPoint = playerabcds;
        player.magicDefencePoint = playerabcds;
        player.speed = playerabcds;
        //Enemyを生成、ステータスを渡す
        (int enemyhp, int enemyabcds) = statuscalc.EnemyCalcStatus(enemy.level, enemySyuzokuchi);
        enemy.hp = enemyhp;
        enemy.attackPoint = enemyabcds;
        enemy.defencePoint = enemyabcds;
        enemy.magicAttackPoint = enemyabcds;
        enemy.magicDefencePoint = enemyabcds;
        enemy.speed = enemyabcds;

        //リストに追加
        List<Charactor> charactors = new List<Charactor>();
        charactors.Add(player);
        charactors.Add(enemy);

        var battlers = new List<IBattleable>();
        foreach (var c in charactors)
        {
            var battleable = c.GetComponent<IBattleable>();
            if (battleable != null)
            {
                battlers.Add(battleable);
            }
        }
        battlers.Sort((a, b) => b.speed - a.speed);


        //リスト内をループ
        while (true)
        {
            battlers[0].Attack();
            int damagePoint = statuscalc.DamagePointCalc(battlers[0], battlers[1]);
            battlers[1].BeDamaged(damagePoint);

            if (battlers[1].hp <= 0)
            {
                Debug.Log("敵が倒れた");
                break;
            }

            battlers[1].Attack();
            damagePoint = statuscalc.DamagePointCalc(battlers[1], battlers[0]);
            battlers[0].BeDamaged(damagePoint);

            if (battlers[0].hp <= 0)
            {
                Debug.Log("自分は倒れた");
                break;
            }

        }

    }



}