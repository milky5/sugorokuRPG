using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //それぞれがUpdate回す(どこで何が動いているのかわかりにくい)
        //これがUpdate回して、他のクラスを管理（Update内がすごい行になる）

        //int remainMass;  BeRolledDice; GameUIManager; ShowInStoryCanvas; 
        //Vector3 playerPos; BeRolledDice (サイコロを初期位置に戻すため); CameraController;
        //StoryList story; ShowInStoryCanvas;
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
