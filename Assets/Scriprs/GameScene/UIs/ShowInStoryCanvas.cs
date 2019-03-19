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

    public bool isTextEnd;

    public void Show(StoryList story)
    {
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

    //ShowInStoryCanvasからProgramにアクセスし、フラグを変更する
    //  相互関係してしまいスパゲッティのもとになる

    //ProgramのupdateでShowInstoryCanvasのフラグにアクセスする
    //  Update重くない…？
    //  というか、isTextEndをfalseにできないから、永遠呼ばれてしまう
    //  isTextEndがfalseのときは、Updateでtrueになるまで監視
    //  isTextEndがtrueになったら、isTrunBeganみたいなやつをtrueにする
    //  isTextEnd && !isTurnBegan
}
