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
    }
}
