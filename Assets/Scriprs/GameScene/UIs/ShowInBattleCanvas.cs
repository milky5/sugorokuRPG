using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class ShowInBattleCanvas : MonoBehaviour
{
    /*

    [SerializeField] GameObject battleCanvas;
    [SerializeField] GameObject buttons;
    [SerializeField] Text text;

    [SerializeField] Player player;
    [SerializeField] Enemy enemy;



    //プレイヤーのステータスを取得
    int playerlevel = 10;
    int playerhp = 20;
    int playerattackPoint = 10;
    int playerdefencePoint = 10;
    int playermagicAttackPoint = 10;
    int playermagicDefencePoint = 10;
    int playerspeed = 10;
    string playerName = "テストさん";

    //敵のステータスを取得
    int enemylevel = 10;
    int enemyhp = 20;
    int enemyattackPoint = 10;
    int enemydefencePoint = 10;
    int enemymagicAttackPoint = 10;
    int enemymagicDefencePoint = 10;
    int enemyspeed = 10;
    string enemyName = "スライム";

    bool isCoroutineRunning;



    void AllProceccing()
    {
        
        BattleCanvasをアクティブに

        プレイヤーを取得、プレイヤーのステータスを取得(計算させるか取得するか)
        敵を生成(するネタをもらう必要あり)、敵のレベル・ステータスを作成(計算させる)

        テキストに"敵が現れた！"


        ※ public (string[], bool) MethodName() ※

        ※"{activeplayer.charactorName}はどうする？"
        ボタンを表示
        ボタンが押されたらボタンを非表示
        プレイヤーと敵のステータスをもとに、ダメージ計算をして、
        "プレイヤーの攻撃！敵に○ダメージ！敵のHPが○○になった。",false
        もしどちらかのHPが0になったら、breakする、で"○○は倒れた",trueをreturnする？
        ※どうする？

        もしどちらかが倒れたら終わり

        




        //BattleCanvasをアクティブにする
        battleCanvas.SetActive(true);

        //PlayerとEnemyのステータスを取得し、フィールドに代入

        //テキストに表示
        text.text = "敵が現れた！";

        Loop();
    }


    void Loop()
    {
        while (true)
        {
            if (isCoroutineRunning)
            {
                break;
            }


            text.text = null;
            text.text = $"{playerName}はどうする？";

            //2つのボタンをアクティブにする
            buttons.SetActive(true);

            //ボタンが押されたら
            //ボタンを非アクティブにする
            buttons.SetActive(false);
            //引数でもらう
            GameObject clicked = buttons;
            if (clicked.CompareTag("nomal"))
            {
                //攻撃
            }
            else if (clicked.CompareTag("magic"))
            {
                //魔法攻撃
            }

            //攻撃なのか魔法攻撃なのかを判断し、そのステータスで計算をする
            //public int DamagePointCalc(IBattleable attacker, IBattleable defencer)

            //計算をするにあたって、乱数を出す
            //public float DamageRatioGenerator()

            int ransu = Random.Range(0, 100);

            float ratio = 1.0f;

            if (0 <= ransu && ransu < 8)
            {
                ratio = 1.2f;
            }
            else if (8 <= ransu && ransu < 25)
            {
                ratio = 1.1f;
            }
            else if (25 <= ransu && ransu < 75)
            {
                ratio = 1.0f;
            }
            else if (75 <= ransu && ransu < 92)
            {
                ratio = 0.9f;
            }
            else if (92 <= ransu && ransu < 100)
            {
                ratio = 0.8f;
            }
            else
            {
                ratio = 1.0f;
            }

            //ダメージ量の計算をする
            //引数とかでもらう
            IBattleable attacker = player.GetComponent<IBattleable>();
            IBattleable defencer = enemy.GetComponent<IBattleable>();

            int iryoku = 50;

            var damageAmount = ((attacker.level * 2 / 5 + 2) * (iryoku * attacker.attackPoint / defencer.defencePoint) / 50 + 2) * ratio;
            int damagePoint = (int)damageAmount;


            var attackStr = attacker.Attack();
            var defenceStr = defencer.BeDamaged(damagePoint);

            var str = new string[] { attackStr, defenceStr[0], defenceStr[1] };

            StartCoroutine(ShowStorys(str, End));
            isCoroutineRunning = true;
        }
    }


    void End(bool end)
    {
        if (!end)
        {
            isCoroutineRunning = false;
            Loop();
        }
        else
        {
            //○○は倒れた！
            battleCanvas.SetActive(false);
        }
    }





























    public void OnButtonClicked(GameObject clicked)
    {
    }

    public IEnumerator ShowStorys(string[] strs, UnityAction<bool> callback)
    {
        int row = 0;
        foreach (var str in strs)
        {
            if (row % 3 == 0)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                text.text = null;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (Input.GetMouseButton(0))
                {
                    text.text += str[i];
                    yield return null;
                }
                else
                {
                    text.text += str[i];
                    yield return new WaitForSeconds(0.1f);
                }
            }
            text.text += "\n";
            row++;
        }
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        text.text = null;
        callback(true);
    }

}



















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

        CalcStatus(enemySyuzokuchi);

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

    private void CalcStatus(int enemySyuzokuchi)
    {
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
    }
}


























public class statuscalc
{
    float playerSyuzokuchi = 60.0f;
    //float level;
    float HP;
    float ABCDS;
    int hp;
    int abcds;

    //使う可能性
    //プレイヤー　エネミー　魔王
    //種族値やレベルが変わる

    public (int, int) PlayerCalcStatus(int level)
    {
        HP = playerSyuzokuchi * 2.0f * (level / 100.0f) + (10.0f + level);
        hp = (int)HP;
        ABCDS = playerSyuzokuchi * 2.0f * (level / 100.0f) + 5.0f;
        abcds = (int)ABCDS;
        return (hp, abcds);
    }

    public (int, int) EnemyCalcStatus(int level, int syuzokuti)
    {
        HP = syuzokuti * 2.0f * (level / 100.0f) + (10.0f + level);
        hp = (int)HP;
        ABCDS = syuzokuti * 2.0f * (level / 100.0f) + 5.0f;
        abcds = (int)ABCDS;
        return (hp, abcds);
    }

    /// <summary>
    /// <param name="attacker">IAttackable</param>
    /// <param name="defencer">IDefenceable</param>
    /// </summary>
    /// <returns></returns>
    public int DamagePointCalc(IBattleable attacker, IBattleable defencer)
    {
        int iryoku = 50;
        float ransu = DamageRatioGenerator();

        var damagePoint = ((attacker.level * 2 / 5 + 2) * (iryoku * attacker.attackPoint / defencer.defencePoint) / 50 + 2) * ransu;

        return (int)damagePoint;
    }

    public float DamageRatioGenerator()
    {
        int ransu = Random.Range(0, 100);

        float ratio = 1.0f;

        if (0 <= ransu && ransu < 8)
        {
            ratio = 1.2f;
        }
        else if (8 <= ransu && ransu < 25)
        {
            ratio = 1.1f;
        }
        else if (25 <= ransu && ransu < 75)
        {
            ratio = 1.0f;
        }
        else if (75 <= ransu && ransu < 92)
        {
            ratio = 0.9f;
        }
        else if (92 <= ransu && ransu < 100)
        {
            ratio = 0.8f;
        }

        return ratio;
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

    */
}

