using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    BeRolledDice beRolledDice;
    int diceNumber;
    Rigidbody rb;

    private void Start()
    {
        beRolledDice = GameObject.Find("Dices").GetComponent<BeRolledDice>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, -60, 60) * 7 * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            if (rb.useGravity == false)
            {
                rb.useGravity = true;

                diceNumber = Random.Range(1, 7);
                Debug.Log($"出た目は {diceNumber}");
            }
        }

        if (transform.position.y < 1)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            beRolledDice.OnRollingExit(diceNumber);
        }
    }
}
