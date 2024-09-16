using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class tCreateBox : MonoBehaviour
{
    //http用
    private string _hostUrl;
    private string _passUrl = @"CreateUser.php";
    WWWForm _form;

    /*ゲームオブジェクト変数*/
    GameObject _buttonBox;

    /*コンポーネントの取得*/
    Text _createText;
    Text _nameText;

    void Start()
    {
        /*ゲームオブジェクトの取得*/
        _buttonBox = GameObject.Find("buttonBox");

        /*コンポーネントの取得*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;    
        _nameText = GameObject.Find("nameText").GetComponent<Text>();
        _createText = GameObject.Find("createText").GetComponent<Text>();

        /*buttonBoxを一時的に消す*/
        _buttonBox.SetActive(false);

        /*表示テキストの初期化*/
        _createText.text = "入学願書";
    }


    private void Update()
    {
        if (NetManager.s_httpResult != null)
        {
            //結果の出力
            _createText.text = NetManager.s_httpResult;
        }

    }

    /*ボタンメソッド*/
    //出願ボタン
    public void CreatePostB()
    {
        /*テキスト入力判定*/
        if(_nameText.text != String.Empty)
        {
            //debug.
            Debug.Log("create");

            //userDataの作成
            PlayerPrefs.SetString("userID", "0001");
            PlayerPrefs.SetString("userPass", "abcd");
            PlayerPrefs.SetString("userName",_nameText.text);

            //formの作成
            _form = new WWWForm();
            _form.AddField("userID", "0001");
            _form.AddField("userPass", "abcd");
            _form.AddField("userName", _nameText.text);

            //post通信
            StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl, _passUrl, _form));

            //テキスト表示
            _createText.text = "願書提出中...";
        }
        else
        {
            //エラー分
            _createText.text = "入力値が不正です！";

        }

    }
    //戻るボタン
    public void CreateReturnB()
    {
        /*buttonBoxを再生成*/
        _buttonBox.SetActive(true);

        /*NetManagerの初期化*/
        NetManager.s_httpResult = null;

        /*自身の削除*/
        Destroy(this.gameObject);
    }
}