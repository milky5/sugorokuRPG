using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject fakeDice;
    [SerializeField] GameObject realDice;
    public CharactorStatusKeeper statusKeeper;
    Vector3 dicePosition;

    // Start is called before the first frame update
    void Start()
    {
        statusKeeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
        //fakeDice = GameObject.Find("fakeDice");
        //realDice = GameObject.Find("PreDice");
        //dicePosition = new Vector3(0, 4, 0);
            //realDice.transform.position;

    }

    private void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(statusKeeper.remainMass);

        if (Input.GetMouseButtonDown(0))
        {
            if (realDice.GetComponent<Rigidbody>() == null)
            {
                realDice.AddComponent<Rigidbody>();
            }
        }

        //もしダイスののy座標が1以下になったら
        if (realDice.transform.position.y < 1)
        {
            int diceNumber = Random.Range(1, 7);
            realDice.SetActive(false);
            fakeDice.SetActive(true);
            statusKeeper.remainMass = diceNumber;
            Debug.Log(diceNumber);
            statusKeeper.SetStatus();
        }
        else
        {
            transform.Rotate(new Vector3(45, -60, 60) * 7 * Time.deltaTime);
        }

        if (statusKeeper.remainMass == 0)
        {
            fakeDice.SetActive(false);
            //realDice.transform.position = new Vector3(statusKeeper.playerPos.x, dicePosition.y, dicePosition.z);
            realDice.SetActive(false);
        }
    }
}
