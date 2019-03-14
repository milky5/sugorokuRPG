#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject fakeDice;
    [SerializeField] GameObject realDice;
    [SerializeField] CharactorStatusKeeper keeper;
    [SerializeField] PlayerMover playerMover;
    Vector3 dicePosition;
    bool isOnMoveEnd;
    float realDiceDefaltPosY = 4.0f;

    void Start()
    {
        keeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
    }

    void Update()
    {

        if (isOnMoveEnd) return;

        if (keeper.remainMass == 0)
        {
            isOnMoveEnd = true;
            OnMoveExit();
        }
    }

    public void OnRollingExit(int diceNumber)
    {
        keeper.remainMass = diceNumber;
        realDice.SetActive(false);
        fakeDice.SetActive(true);
        playerMover.SetStatus();
        isOnMoveEnd = false;
    }

    void OnMoveExit()
    {
        fakeDice.SetActive(false);
        float posX = keeper.playerPos.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        realDice.transform.position = new Vector3(posX, realDiceDefaltPosY, posZ);
    }
}
