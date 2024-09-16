using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class tLoginBox : MonoBehaviour
{
    //http用
    private string _hostUrl;
    private string _passUrl;
    WWWForm _form;

    /*ゲームオブジェクト変数*/
    GameObject _buttonBox;

    /*コンポーネント変数*/
    Text _loginText;

    /*変数*/
    bool _isUserId = false;
    string _userID;
    string _userPass;
    string _userName;
    string _sessionKey;

    void Start()
    {
        /*ゲームオブジェクトの取得*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*コンポーネントの取得*/
        _loginText = GameObject.Find("loginText").GetComponent<Text>();

        /*buttonBoxを一時的に消す*/
        _buttonBox.SetActive(false);

        /*uesrIDの確認*/
        var tempID = PlayerPrefs.GetString("userID", String.Empty);
        var tempPass = PlayerPrefs.GetString("userPass", String.Empty);
        var tempName = PlayerPrefs.GetString("userName", String.Empty);
        if (tempID != string.Empty && tempPass != string.Empty)
        {
            //IDがある場合
            _loginText.text = $"接続中です...";
            _userID = tempID;
            _userPass = tempPass;
            _userName = tempName;
            _isUserId = true;
        }
        else
        {
            //IDが無い場合
            _loginText.text = $"学生情報がありません。\nまずは入学しましょう。";
            NetManager.s_httpResult = null;
            _isUserId = false;
        }

        /*Post通信*/
        if(_isUserId == true)
        {
            //uriの設定
            _passUrl = @"Login.php";
            //セッションKEYの作成
            _sessionKey = MakeSessionKey(8);
            //formの作成
            _form = new WWWForm();
            _form.AddField("userID", _userID);
            _form.AddField("userPass", _userPass);
            _form.AddField("userName", _userName);
            _form.AddField("sessionKey", _sessionKey);
            StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl,_passUrl,_form));
        }

    }

    private void Update()
    {
        //テキストの更新
        if (NetManager.s_httpResult != null)
        {
            _loginText.text = NetManager.s_httpResult;
        }
    }


    /*ボタンメソッド*/
    //戻るボタン
    public void LoginReturnB()
    {
        /*buttonBoxを再生成*/
        _buttonBox.SetActive(true);

        /*NetManagerの初期化*/
        NetManager.s_httpResult = null;

        /*自身の削除*/
        Destroy(this.gameObject);
    }

    /*自作メソッド*/
    /// <summary>
    /// セッションキーを作成する関数。ランダムな文字列数値を作成する。
    /// </summary>
    /// <param name="num">文字数</param>
    /// <returns></returns>
    string MakeSessionKey(int num)
    {
        /*変数*/
        //文字列を用意
        var txt = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //文字数
        var n = 8;
        //乱数発生用
        var random = new System.Random();
        //結果格納用
        string result="";

        /*ランダム文字列作成*/
        for(int i = 0 ; i < n ; i++)
        {
            result += txt[random.Next(txt.Length)];
        }

        return result;
    }
}
