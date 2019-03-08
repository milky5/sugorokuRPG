using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInStoryCanvas : MonoBehaviour
{
    CharactorStatusKeeper keeper;
    [SerializeField] GameObject canvas;
    [SerializeField]GameObject imageObject;
    Image image;
    [SerializeField] Sprite battle;
    [SerializeField] Sprite help;
    bool isOnMoveEnd;
    bool isShowing;

    private void Start()
    {
        keeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
        image = GameObject.Find("Image").GetComponent<Image>();
    }

    private void Update()
    {
        if (isShowing) return;

        if (keeper.remainMass == 0)
        {
            isOnMoveEnd = true;
        }
        else
        {
            isOnMoveEnd = false;
        }

        if (isOnMoveEnd)
        {
            isShowing = true;
            Show();
        }
    }

    void Show()
    {
        canvas.SetActive(true);
        imageObject.GetComponent<Image>().sprite = battle;
        Debug.Log("ストーリーを見せます");


        //isShowing = false;
    }
}
