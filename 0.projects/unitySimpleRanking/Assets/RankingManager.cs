using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
//追加
using UnityEngine.Networking;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    /*Http通信*/
    //getRanking
    const string _getPass = @"getRanking.php";
    //postRanking
    const string _postPass = @"postRanking.php";
    //resetDB
    const string _resetPass = @"resetDB.php";
    //createTable
    const string _createPass = @"createTable.php";

    /*ランキング表示*/
    string _rankingText = string.Empty;

    /*uGUI*/
    //サーバURLの入力
    InputField _serverUrlField;
    //テーブル受信
    Text _rankingLabel;
    InputField _gettTableField;
    //テーブル更新
    InputField _upTableField;
    InputField _nameField;
    InputField _scoreField;
    //テーブル作成
    InputField _createTableField;
    InputField _colum1TableField;
    InputField _colum2TableField;
    InputField _colum3TableField;

    // Start is called before the first frame update
    void Start()
    {
        /*uGUI用*/
        //サーバURL
        _serverUrlField = GameObject.Find("serverUrlField").GetComponent<InputField>();
        //テーブル受信
        _rankingLabel = GameObject.Find("RankingLabel").GetComponent<Text>();
        _gettTableField = GameObject.Find("getTableField").GetComponent<InputField>();
        //テーブル更新
        _upTableField = GameObject.Find("upTableField").GetComponent<InputField>();
        _nameField = GameObject.Find("nameField").GetComponent<InputField>();
        _scoreField = GameObject.Find("scoreField").GetComponent<InputField>();
        //テーブル作成
        _createTableField = GameObject.Find("createTableField").GetComponent<InputField>();
        _colum1TableField = GameObject.Find("colum1Field").GetComponent<InputField>();
        _colum2TableField = GameObject.Find("colum2Field").GetComponent<InputField>();
        _colum3TableField = GameObject.Find("colum3Field").GetComponent<InputField>();

        /*初期化*/
        _serverUrlField.text = @"http://mahiro.punyu.jp/SimpleRanking/";
        _gettTableField.text = @"Ranking";
        _upTableField.text = @"Ranking";
        _createTableField.text = @"Ranking";
        _colum1TableField.text = @"rank";
        _colum2TableField.text = @"name";
        _colum3TableField.text = @"score";

    }

    // Update is called once per frame
    void Update()
    {
        //ランキングの更新
        _rankingLabel.text = _rankingText;
    }

    /*ボタン用のメソッド*/
    public void GetRanking()//受信
    {
        //Unityでhttp通信を行うためには非同期通信が必要
        //そのためStartCoroutineメソッドを使って、別スレッドにメソッドを実行させる
        string tes = _serverUrlField.text;
        StartCoroutine(GetRequest(_serverUrlField.text,_getPass));
    }
    public void PostRanking()//送信
    {
        StartCoroutine(PostRequest(_serverUrlField.text,_postPass));
    }
    public void ResetDB()//データベースの初期化
    {
        StartCoroutine(GetRequest(_serverUrlField.text,_resetPass));
    }
    public void CreateTable()//テーブルの作成
    {
        StartCoroutine(PostCreate(_serverUrlField.text,_createPass)) ;
    }

    /*Httpメソッド*/
    //別スレッドで処理をさせる(コルーチンとして処理をさせる)ためには  
    //IEnumeratorを返り値として持つ必要があります。
    //これは別スレッドから結果が返ってくるまで非同期に何度も結果を要求する必要があるためです。
    IEnumerator GetRequest(string serverUrl, string getPass)
    {
        /*URLの作成*/
        string _getUrl = serverUrl + getPass + @"?" + @"table=" + _gettTableField.text;

        /*GetRequest*/
        //usingによりスコープを抜けたら自動でメモリ解放
        using UnityWebRequest _getRequest = UnityWebRequest.Get(_getUrl);

        /*yield return*/
        //yield returnにより、結果が還るまでこのメソッド内の以降の処理が行われない。
        //メソッドの呼び出しもとに戻って別の処理を継続する。
        yield return _getRequest.SendWebRequest();

        //通信のエラー処理
        if (_getRequest.isNetworkError || _getRequest.isHttpError)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.Log(_getRequest.error);
            Debug.Log(_getUrl);
        }
        else
        {
            //ランキングテキストの更新
            Debug.Log(_getUrl);
            _rankingText = _getRequest.downloadHandler.text;
        }
    }
    //Post通信を行うメソッド
    //こちらはデータの送信を行う。
    IEnumerator PostRequest(string serverUrl, string postPass)
    {
        /*URLの作成*/
        string _postUrl = serverUrl + postPass;

        /*フォームの作成*/
        //ポストはURLのみの通信ではなく、URLに大してFromを渡すことで通信する。
        //なのでフォームを作成する必要がある。
        WWWForm form = new WWWForm();
        form.AddField("table", _gettTableField.text);
        form.AddField("name", _nameField.text);
        form.AddField("score", _scoreField.text);

        /*PostRequest*/
        //usingによりスコープを抜けたら自動でメモリ解放
        using UnityWebRequest _postRequest = UnityWebRequest.Post(_postUrl, form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*エラー処理*/
        if (_postRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(_postRequest.error);
            Debug.Log(_postUrl);
        }
        else
        {
            //通信成功
            Debug.Log(_postRequest.downloadHandler.text);
            Debug.Log(_postUrl);
        }
    }
    //テーブルの作成
    IEnumerator PostCreate(string serverUrl, string createPass)
    {
        /*URLの作成*/
        string _postUrl = serverUrl + createPass;

        /*フォームの作成*/
        //ポストはURLのみの通信ではなく、URLに大してFromを渡すことで通信する。
        //なのでフォームを作成する必要がある。
        WWWForm form = new WWWForm();
        form.AddField("table", _createTableField.text);
        form.AddField("colum1",_colum1TableField.text);
        form.AddField("colum2", _colum2TableField.text);
        form.AddField("colum3", _colum3TableField.text);

        /*PostRequest*/
        //usingによりスコープを抜けたら自動でメモリ解放
        using UnityWebRequest _postRequest = UnityWebRequest.Post(_postUrl, form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*エラー処理*/
        if (_postRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(_postRequest.error);
            Debug.Log(_postUrl);
        }
        else
        {
            //通信成功
            Debug.Log(_postRequest.downloadHandler.text);
            Debug.Log(_postUrl);
        }
    }
}

