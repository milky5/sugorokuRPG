#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInStoryCanvas : MonoBehaviour
{
    CharactorStatusKeeper keeper;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject imageObject;
    [SerializeField] Image image;
    [SerializeField] Sprite battle;
    [SerializeField] Sprite help;
    bool isOnMoveEnd;
    bool isShowing;
    [SerializeField] Text storyText;
    [SerializeField] StoryMemo storyMemo;
    [SerializeField] ShowTextFiled showTextFiled;

    private void Start()
    {
        keeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
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

        StartCoroutine(showTextFiled.ShowStorys(storyMemo.first, Hide));

        //imageObject.GetComponent<Image>().sprite = battle;
        //Debug.Log($"{keeper.story}を見せます");
        //isShowing = false;
    }

    void Hide(bool end)
    {
        canvas.SetActive(false);
    }







}
