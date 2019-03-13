using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharactorStatusKeeper : MonoBehaviour
{
    //各プレイヤーのステータスを取ってくる
    //{ get; set;}を活用

    public GameObject playerObj;
    public GameObject enemy;
    public Player player;
    public int remainMass = int.MinValue;
    public Vector3 playerPos;
    public StoryList story;

    private void Start()
    {
        playerObj = GameObject.Find("Eevee");
        //player = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        enemy = GameObject.Find("Enemy");
        remainMass = int.MinValue;
        
    }

    private void Update()
    {
        remainMass = player.remainMass;
        playerPos = playerObj.transform.position;
        story = player.story;
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
