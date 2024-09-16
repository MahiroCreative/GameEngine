using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class tNoticeBox : MonoBehaviour
{
    //http用
    private string _hostUrl;
    private string _passurl;

    /*ゲームオブジェクト変数*/
    GameObject _buttonBox;

    /*コンポーネント変数*/
    Text _noticeText;

    void Start()
    {
        /*ゲームオブジェクトの取得*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*コンポーネントの取得*/
        _noticeText = GameObject.Find("noticeText").GetComponent<Text>();

        /*buttonBoxを一時的に消す*/
        _buttonBox.SetActive(false);

        /*textの初期化*/
        _noticeText.text = $"接続中です...";

        /*Get通信*/
        _passurl = @"Notice.php";
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, _passurl));
        
    }

    private void Update()
    {
        //テキストの更新
        if (NetManager.s_httpResult != null)
        {
            _noticeText.text = NetManager.s_httpResult;
        }
    }

    /*ボタンメソッド*/
    //戻るボタン
    public void NoticeReturnB()
    {
        /*buttonBoxを再生成*/
        _buttonBox.SetActive(true);

        /*http初期化*/
        NetManager.s_httpResult = null;

        /*自身の削除*/
        Destroy(this.gameObject);
    }
}
