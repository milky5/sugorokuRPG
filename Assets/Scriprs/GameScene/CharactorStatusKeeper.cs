using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharactorStatusKeeper : MonoBehaviour
{
    //各プレイヤーのステータスを取ってくる
    //{ get; set;}を活用

    public GameObject player;
    public GameObject enemy;
    public Player pplayer;
    public int remainMass = int.MinValue;
    public Vector3 playerPos;

    private void Start()
    {
        player = GameObject.Find("Eevee");
        //player = GameObject.Find("Player");
        pplayer = player.GetComponent<Player>();
        enemy = GameObject.Find("Enemy");
        remainMass = int.MinValue;
        
    }

    private void Update()
    {
        remainMass = pplayer.remainMass;
        playerPos = player.transform.position;
    }

    void PlayerAttack()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        var activePlayer = players.Where(n => n.GetComponent<Player>().isActive);
        foreach (var ac in activePlayer)
        {
            ac.GetComponent<IAttackable>().Attack();
        }
    }

    public void SetStatus()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        var activePlayer = players.Where(n => n.GetComponent<Player>().isActive);
        foreach (var ac in activePlayer)
        {
            var acPlayer = ac.GetComponent<Player>();
            //acPlayer.Roll();
            acPlayer.remainMass = this.remainMass;
            acPlayer.Move();
        }
    }
}
