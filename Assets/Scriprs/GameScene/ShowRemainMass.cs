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

    private void Update()
    {
        updateRemainMass = keeper.remainMass;

        if (updateRemainMass != 0)
        {
            text.text = $"あと {updateRemainMass}マス";
        }
        else if (updateRemainMass == 0)
        {
            remainMass.SetActive(false);
        }
    }

    public void TestShow()
    {
        remainMass.SetActive(true);
    }
}
