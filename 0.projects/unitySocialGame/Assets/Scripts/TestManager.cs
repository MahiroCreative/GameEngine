using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class TestManager : MonoBehaviour
{
    /*変数*/
    //http用
    string _hostUrl = @"http://localhost/phpSocialGame/";
    //string _hostUrl = @"https://ohara-fic-game.fool.jp/2023GameEngineFor2022/socialGame/";
    //コンポーネント
    TextMeshProUGUI resultLabel;

    /*Start*/
    private void Start()
    {
        /*オブジェクト(orコンポーネント)の取得*/
        resultLabel = GameObject.Find("httpResLabel").GetComponent<TextMeshProUGUI>();
    }


    /*ゲームループ*/
    private void Update()
    {
        /*GUI更新*/
        //httpレスポンス確認
        resultLabel.text = NetManager.s_httpResult;
    }

    /*ボタンメソッド*/

    public void TestGet()
    {
        /*URLとクエリ*/
        string passUrl = @"TestGetHttp.php";
        string query = "tes1=1&tes2=2";

        //Getメソッドの実行
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, passUrl, query));
    }
    public void TestPost()
    {
        /*URLとクエリ*/
        string passUrl = @"TestPostHttp.php";

        /*フォームの作成*/
        WWWForm form = new WWWForm();
        form.AddField("userID", 1234);
        form.AddField("userName", "Takashi");
        form.AddField("userPass", 4321);

        //Getメソッドの実行
        StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl, passUrl, form));
    }

}
