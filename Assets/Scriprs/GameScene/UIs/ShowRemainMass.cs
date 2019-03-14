#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRemainMass : MonoBehaviour
{
    [SerializeField] CharactorStatusKeeper keeper;
    [SerializeField] Text text;
    [SerializeField] GameObject remainMass;
    int updateRemainMass;
    bool isActive;

    private void Update()
    {
        if (isActive && !keeper.isPlayerMoving)
        {
            remainMass.SetActive(false);
            isActive = false;
        }

        if (!keeper.isPlayerMoving) return;


        updateRemainMass = keeper.remainMass;

        remainMass.SetActive(true);
        isActive = true;

        if (updateRemainMass != 0)
        {
            text.text = $"あと {updateRemainMass}マス";
        }

    }
}
