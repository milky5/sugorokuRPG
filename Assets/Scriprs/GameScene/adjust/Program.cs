using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// 宣言, Start(), Update()
public　partial class Program : MonoBehaviour
{
    [SerializeField] CharactorStatusKeeper keeper;
    [SerializeField] GameUIManager gameUIManager;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    [SerializeField] Dice diceClass;
    [SerializeField] ShowRemainMass showRemainMass;
    [SerializeField] WhosTurn whosTurn;

    List<Player> players = new List<Player>();
    Player activePlayer;
    GameObject activePlayerObj;

    bool isOneTurnStart;
    bool isPlayerChoicing;
    bool isDiceBeganToFall;

    bool isDiceFinishedFalling;
    bool isPlayerFinishedMoving;

    // Start is called before the first frame update
    void Start()
    {
        //Staticクラスから読み出す
        //Awakeのほうがいいのかも
        //というかPlayerクラスにコンストラクタ作ってほしい
        players.Add(new Player());
        players[0].playerName = "テストさん";
    }

    // Update is called once per frame
    void Update()
    {
        //進行状態をフラグで管理する
        isDiceBeganToFall = diceClass.isDiceBeganToFall;
        isDiceFinishedFalling = diceClass.isDiceFinishedFalling;

        //誰かのターンが終わって誰かのターンが始まる
        if (isOneTurnStart)
        {
            TurnOrder();
            GetActivePlayer();
            RenewalData();
            StartCoroutine(whosTurn.ShowWhosTurn());
        }

        //プレイヤーがこのターン何をするかを選択中
        if (isPlayerChoicing)
        {
            gameUIManager.ShowCanvas();
        }

        // Diceクラスにて判定を実施中
        //サイコロが落ち始めたら
        if (isDiceBeganToFall)
        {
            gameUIManager.HideCanvas();
        }
    }













    private void PlayerOneTurn()
    {
        //今誰のターンなのか判定する
        var playersObj = GameObject.FindGameObjectsWithTag("Player");
        var activePlayerObj = playersObj.Where(n => n.GetComponent<Player>().isActive);
        foreach (var acObj in activePlayerObj)
        {
            //手番の人のステータスをStatusKeeperで保持するようにする
            keeper.playerObj = acObj;
            keeper.player = acObj.GetComponent<Player>();
        }

        //○○のターン！というイメージを表示
        StartCoroutine(whosTurn.ShowWhosTurn());

        //[マップ][サイコロ][アイテム][ステータス]のボタンを表示する
        gameUIManager.ShowCanvas();
        //ボタンが押されたら、gameUIManagerがそれぞれの処理をする

        //現在        //サイコロボタンが押されたらサイコロが動く＆ backButtonがfalseに
        //サイコロの落ち始めをフラグ管理、落ち始めたらgameUIManager.HideCanvas()
        if (isDiceBeganToFall)
        {
            gameUIManager.HideCanvas();
        }

        //サイコロの落ち終わりをフラグ管理、
        //落ち終わったら、出目を伝える、本物偽物を入れ替える、プレイヤーを動かす(PlayerMoverクラス)
        if (isDiceFinishedFalling)
        {

        }

        //showRemainMassをアクティブに。

        //プレイヤーの動き終わりをフラグ管理
        //現在      //動き終わったら、(BeRolledDiceクラス)の、フェイクダイスを非表示、
        //現在      //サイコロポジションの最適化(空のオブジェクト・リアルダイスの高さ)
        if (isPlayerFinishedMoving)
        {

        }

        //動き終わったら、showRemainMassを非アクティブに。
        //動き終わったら、StoryCanvasをactiveに
        showInStoryCanvas.Show();
        //文章を読み終わったら、Storycanvasをfalseに
        showInStoryCanvas.Hide(true);
    }

    void Memo()
    {
        /*
         * GameSceneが読み込まれる
         *      プレイ人数に応じてPlayerを生成(名前も代入)
         * 最初の導入ストーリーが開始(StoryCanvasにて描画)
         *      導入ストーリー中にて、アイテムを取得、ステータスに反映
         * StoryCanvasを非アクティブ化
         * 
         * 
         * 【LoopB】
         * プレイヤーの数だけLoopAを繰り返す
         * 【LoopA】
         * プレイヤー(Player[0])のステータスをアクティブに
         * ChoiceCanvasをアクティブ化
         * アクティブなプレイヤーのアイテムやステータスを取得
         * アクティブなプレイヤーにカメラを合わせる
         * サイコロ振る
         * プレイヤーが動いてTriggerにて処理
         * 止まったらStoryCanvasにてイベント再生
         * 
         *      ＜もし強制イベントが入ったら＞
         *          StoryCanvasをアクティブ化
         *          1人目に説明終わったよっていうフラグ
         *          最後は○人目だよっていうフラグ
         * 
         * プレイヤーのステータスを変更
         * StoryCanvasを非アクティブ化
         * アクティブなプレイヤーのステータスを非アクティブに
         * 【End LoopA】
         * 【End LoopB】
         * 
         * 
         * 全員がゴールに着いたらStoryCanvasをアクティブ化
         * 戦闘開始
         * 戦闘終了
         * ゲームエンド
         * 
         */
    }
}
