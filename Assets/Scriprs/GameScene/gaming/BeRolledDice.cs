#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject fakeDice;
    [SerializeField] GameObject realDice;
    public CharactorStatusKeeper statusKeeper;
    Vector3 dicePosition;
    bool isOnMoveEnd;
    float realDiceDefaltPosY = 4.0f;

    void Start()
    {
        statusKeeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
    }

    void Update()
    {

        if (isOnMoveEnd) return;

        if (statusKeeper.remainMass == 0)
        {
            isOnMoveEnd = true;
            OnMoveExit();
        }
    }

    public void OnRollingExit(int diceNumber)
    {
        statusKeeper.remainMass = diceNumber;
        realDice.SetActive(false);
        fakeDice.SetActive(true);
        statusKeeper.SetStatus();
        isOnMoveEnd = false;
    }

    void OnMoveExit()
    {
        fakeDice.SetActive(false);
        float posX = statusKeeper.playerPos.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        realDice.transform.position = new Vector3(posX, realDiceDefaltPosY, posZ);
    }
}
