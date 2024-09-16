using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCubeScript3 : MonoBehaviour {
    public GameObject cube;
    private const int nBaseObje = 10;//作成する軸オブジェクト群のオブジェクト数
    private const int nBranchObje = 10;//触手オブジェクト群のオブジェクト数
    private const float fInterval = 0.5f;//相対距離
    private Vector3 v3Interval1 = new Vector3(0.5f,  0.5f, 0.0f);//触手１が伸びていく方向
    private Vector3 v3Interval2 = new Vector3(0.5f, -0.5f, 0.0f);//触手２が伸びていく方向
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        /*実行環境を整えるための初期化*/
        GameObject.Find("Plane").SetActive(false);

        /*軸オブジェクト群の作成用の変数*/
        int i;
        GameObject TempObj, lastGameObje, RootObje;
        Vector3 v3Position = new Vector3(-2.0f, 0.0f, 0.0f);

        /*オブジェクトの取得と初期化*/
        RootObje  = GameObject.Find("Cube");
        RootObje.transform.position = v3Position;//初期位置の設定
        RootObje.transform.parent = null; //親の設定
        //ラストオブジェクトの初期化
        lastGameObje = RootObje;
        //深度の初期化
        int nDepth = 1;

        /*軸オブジェクト群の作成ループ*/
        for (i = 1; i <= nBaseObje; i++)
        {
            v3Position.x += fInterval;//新規生成のオブジェクトの相対距離を代入
            TempObj = MyInstantiate(v3Position, lastGameObje, nDepth);//新しいインスタンスの作成
            lastGameObje = TempObj;//ラストオブジェクトの更新
            nDepth++;//深度の更新
        }

        /*触手オブジェクト群作成用の変数*/
        GameObject lastGameObje1 = lastGameObje;
        GameObject lastGameObje2 = lastGameObje;
        Vector3 v3Position1 = v3Position;
        Vector3 v3Position2 = v3Position;

        /*触手オブジェクト群の作成ループ*/
        for (i = 1; i <= nBranchObje; i++)
        {
            //一つ目の触手の作成
            v3Position1 += v3Interval1;
            TempObj = MyInstantiate(v3Position1, lastGameObje1, nDepth);
            lastGameObje1 = TempObj;
            //二つ目の触手の作成
            v3Position2 += v3Interval2;
            TempObj = MyInstantiate(v3Position2, lastGameObje2, nDepth);
            lastGameObje2 = TempObj;
            //それぞれの深度の更新
            nDepth++;
        }
    }

    /// <summary>
    /// 【ユーザ定義】カスタムインスタンス。
    /// 新しいゲームオブジェクトを作成し、それの初期化を行う関数
    /// </summary>
    /// <param name="v3GenPos"></param>
    /// <param name="GenParent"></param>
    /// <param name="nDepth"></param>
    /// <returns></returns>
    GameObject MyInstantiate(Vector3 v3GenPos, GameObject GenParent, int nDepth)
    {
        //Cubeの生成
        GameObject GameObje = Instantiate(cube);
        //生成したCubeの位置を設定
        GameObje.transform.position = v3GenPos;
        //生成したCubeの親を設定
        GameObje.transform.parent = GenParent.transform;
        //生成したCubeのスクリプトを取得
        Transform4_2 ScRef = GameObje.GetComponent<Transform4_2>();
        //取得したスクリプトに深度を代入
        ScRef.nDepth = nDepth;
        //取得したスクリプトのv3BasePosに親との相対距離を代入
        ScRef.v3BasePos = GameObje.transform.position - GameObje.transform.parent.position;
        //生成したCubeの参照を返す
        return GameObje;
    }
}
