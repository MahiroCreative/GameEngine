using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCubeScript2 : MonoBehaviour {
    public GameObject cube;
    private const int nObjCount = 20;
    private const float fInterval = 0.5f;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        /*ルートオブジェクトの初期設定*/
        GameObject RootObje = GameObject.Find("Cube");          // ルートオブジェク
        Vector3 v3Position = new Vector3(-5.0f, 0.0f, 0.0f);    // 位置
        RootObje.transform.position = v3Position;
        RootObje.transform.parent = null;                       // ルートに親なし

        //ラストオブジェクトの更新
        GameObject lastGameObje = RootObje;

        for (int i = 1; i <= nObjCount; i++)
        {
            //オブジェクト生成
            GameObject GameObje = Instantiate(cube);
            v3Position.x += fInterval;
            GameObje.transform.position = v3Position;
            //生成したオブジェクトの親を最後に作成したオブジェクトにする
            //(最後に作成したオブジェクトの子オブジェクトにする)
            GameObje.transform.parent = lastGameObje.transform;
            //作成した子オブジェクトにスクリプトをアタッチ
            Transform4_1 ScRef = GameObje.GetComponent<Transform4_1>();
            //階層の設定(色替えのため)
            ScRef.nDepth = i;
            //ラストオブジェクトの更新
            lastGameObje = GameObje;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
