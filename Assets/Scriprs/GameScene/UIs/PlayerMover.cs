using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] CharactorStatusKeeper keeper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStatus()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        var activePlayer = players.Where(n => n.GetComponent<Player>().isActive);
        foreach (var ac in activePlayer)
        {
            var acPlayer = ac.GetComponent<Player>();
            acPlayer.remainMass = keeper.remainMass;
            acPlayer.Move();
        }
    }
}
