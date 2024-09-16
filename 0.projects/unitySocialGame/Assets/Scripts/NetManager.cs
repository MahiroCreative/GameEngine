using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;



public static class NetManager
{
    /*変数*/
    //Httpリクエストの結果を受け取る変数
    public static string s_httpResult = null;

    /// <summary>
    /// 【HttpGetメソッド(非同期)】
    /// StartCoroutineメソッド経由で実行する。
    /// </summary>
    /// <param name="domainUrl">domainアドレス</param>
    /// <param name="passUrl">apiアドレス</param>
    /// <param name="query">クエリ文字(?は省略)</param>
    /// <returns>IEnumerable型を返す。</returns>
    public static IEnumerator HttpGetEnumerable(string hostUrl, string passUrl, string query=null)
    {
        /*resultの初期化*/
        s_httpResult = null;

        /*URLの作成*/
        //フルapiアドレスを作成し、クエリ文字と合成
        string getUrl = hostUrl + passUrl + $"?{query}";

        /*GetRequest*/
        //usingによりスコープを抜けたら自動でメモリ解放
        using UnityWebRequest getRequest = UnityWebRequest.Get( getUrl );

        /*yield return*/
        //結果が返るまで以降の処理が行われない。
        yield return getRequest.SendWebRequest();

        /*通信エラー処理*/
        //isNetworkErrorは非推奨になりました。
        if(getRequest.result == UnityWebRequest.Result.Success)//成功
        {
            //成功時は接続先を表示
            Debug.Log($"【通信先(成功)：】{getUrl}");
            //結果を代入
            s_httpResult = getRequest.downloadHandler.text;
        }
        else//失敗
        {
            //エラーが起きた場合はエラー内容を表示
            Debug.Log($"【エラー内容：】{getRequest.error}");
            Debug.Log($"【通信先(失敗)：】{getUrl}");
            //接続が失敗したことを通知
            s_httpResult = "接続が失敗しました。";
        }
    }
    /// <summary>
    /// 【HttpPostメソッド(非同期)】
    /// WWWformを作成して第三引数に入れてください。
    /// </summary>
    /// <param name="serverUrl">domain</param>
    /// <param name="postPass">apiアドレス</param>
    /// <param name="form">formデータ</param>
    /// <returns>IEnumerable型を返す。</returns>
    public static IEnumerator HttpPostEnumerable(string serverUrl, string postPass, WWWForm form)
    {
        /*URLの作成*/
        string postUrl = serverUrl + postPass;

        /*PostRequest*/
        using UnityWebRequest postRequest = UnityWebRequest.Post(postUrl, form);

        /*yield return*/
        yield return postRequest.SendWebRequest();

        /*通信エラー処理*/
        //isNetworkErrorは非推奨になりました。
        if (postRequest.result == UnityWebRequest.Result.Success)//成功
        {
            //成功時は接続先を表示
            Debug.Log($"【通信先(成功)：】{postUrl}");
            //結果を代入
            s_httpResult = postRequest.downloadHandler.text;
        }
        else//失敗
        {
            //エラーが起きた場合はエラー内容を表示
            Debug.Log($"【エラー内容：】{postRequest.error}");
            Debug.Log($"【通信先(失敗)：】{postUrl}");
            //接続が失敗したことを通知
            s_httpResult = "接続に失敗しました。";
        }
    }
}
