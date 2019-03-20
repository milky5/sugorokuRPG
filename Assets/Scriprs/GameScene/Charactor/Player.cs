using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charactor, IRollable, IMoveable, IAttackable, IDamageable
{
    public string playerName;
    string haveitem;
    List<ItemList> items;
    int money;

    public bool isActive;
    public int remainMass { get; set; }
    public bool isMoving { get; set; }
    public bool firstMass { get; set; }
    public StoryList story { get; set; }

    private void Start()
    {
        isMoving = false;
        //firstMass = true;
        //Roll();
        //Move();
    }

    private void Update()
    {
        if (isMoving)
        {
            //通常用
            //transform.Translate(new Vector3(1f, 0, 0)*Time.deltaTime);
            //イーブイ用
            transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);
        }
    }

    public void Attack()
    {
        Debug.Log($"{name}の攻撃");
    }

    public void BeDamaged()
    {
        Debug.Log($"{name}のHPが{hp}になった。");
    }

    public void Move()
    {
        //firstMass = true;
        isMoving = true;
    }

    public void Roll()
    {
        remainMass = Random.Range(1, 7);
        Debug.Log($"出目は{remainMass}");
    }
}

//ダミークラス
//class Singleton
//{
//    public int NumberOfParticipant { get; set; }
//    public List<string> playersName { get; set; }
//    public Singleton instance { get; set; }

//    Singleton()
//    {
//    }

//    public static Singleton Instance()
//    {
//        if (instance == null)
//        {
//            instance = new Singleton();
//        }
//        return instance;
//    }
//}
////ダミークラス
//class Program
//{
//    int numberOfP;
//    List<Player> players = new List<Player>();
//    List<string> playersName;

//    void Main()
//    {
//        Singleton s1 = Singleton.Instance();

//        numberOfP = s1.NumberOfParticipant;
//        playersName = s1.playersName;

//        for (int i = 0; i < numberOfP; i++)
//        {
//            players.Add(new Player(playersName[i]));
//        }
//        if (numberOfP != players.Count)
//        {
//            Debug.Log("参加人数とプレイヤーの数があっていません");
//        }
//    }
//}
