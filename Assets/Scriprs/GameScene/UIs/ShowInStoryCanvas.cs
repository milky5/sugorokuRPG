#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInStoryCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Image image;
    [SerializeField] Sprite battle;
    [SerializeField] Sprite help;
    [SerializeField] StoryMemo storyMemo;
    [SerializeField] ShowTextFiled showTextFiled;
    [SerializeField] ShowInBattleCanvas showInBattleCanvas;

    public bool isTextEnd;

    public void Show(StoryList story)
    {
        if (story == StoryList.battle)
        {
            //他のところに行く
            //showInBattleCanvas.Show();
            return;
        }

        canvas.SetActive(true);
        isTextEnd = false;
        //image.sprite = battle;
        StoryContents storyContents = new StoryContents();
        var storyStr = storyContents.ReturnContents(story);
        StartCoroutine(showTextFiled.ShowStorys(storyStr, Hide));
    }

    public void Hide(bool end)
    {
        canvas.SetActive(false);
        isTextEnd = true;
    }

}
