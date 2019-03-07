using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class GameUIManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject whosTurn;
    CharactorStatusKeeper charactorStatus;
    public GameObject mapButton;
    public GameObject itemButton;
    public GameObject diceButton;
    public GameObject statusButton;
    public GameObject backButton;
    public GameObject dice;

    //スタート時に呼ばれる
    private void Start()
    {
        charactorStatus = GetComponent<CharactorStatusKeeper>();
    }

    //このたくさんのボタンがついたオブジェクトを表示
    void ShowCanvas()
    {
        gameUI.SetActive(true);
    }

    //「○○のターン！」というイメージを表示し非表示にする
    IEnumerator ShowWhosTurn()
    {
        //呼出元に　StartCoroutine(ShowWhosTurn());
        whosTurn.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        whosTurn.SetActive(false);
    }

    //未テスト
    //「あと○マス！」というイメージを表示し、テキストを更新する
    IEnumerator ShowRemainMass()
    {
        if (charactorStatus.remainMass != 0)
        {
            Debug.Log(charactorStatus.remainMass);
        }
        else if (charactorStatus.remainMass == 0)
        {
            yield break;
        }
        yield return null;
    }


    public void OnBeClickedTest(GameObject clicked)
    {
        if (clicked.CompareTag("mapButton"))
        {
            Debug.Log("マップボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("itemButton"))
        {
            Debug.Log("アイテムボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("diceButton"))
        {
            Debug.Log("ダイスボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
            dice.SetActive(true);
        }
        else if (clicked.CompareTag("statusButton"))
        {
            Debug.Log("ステータスボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("backButton"))
        {
            Debug.Log("バックボタンが押されました");
            mapButton.SetActive(true);
            itemButton.SetActive(true);
            diceButton.SetActive(true);
            statusButton.SetActive(true);
            backButton.SetActive(false);
        }
    }
}
