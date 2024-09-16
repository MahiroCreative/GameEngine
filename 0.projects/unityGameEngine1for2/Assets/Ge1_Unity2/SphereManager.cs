using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    float size,del;
    GameObject sphere1, sphere2;
    Vector3 speed1, speed2, temp, delVec;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの取得
        sphere1 = GameObject.Find("Sphere1");
        sphere2 = GameObject.Find("Sphere2");
        //ベクトル間確保用
        delVec = new Vector3();
        //反転用
        temp = new Vector3();

        //互いの方向へのベクトル成分の作成
        speed1 = new Vector3();
        speed1 = sphere2.transform.position - sphere1.transform.position;//sphere1からsphere2へのベクトル
        speed1 = speed1.normalized;//単位ベクトル化
        speed1 = speed1 / 50;//速すぎるので1/50に。
        speed2 = new Vector3();
        speed2 = sphere1.transform.position - sphere2.transform.position;//sphere2からsphere1へのベクトル
        speed2 = speed2.normalized;//単位ベクトル化
        speed2 = speed2 / 50;//速すぎるので1/50に。
        //サイズ取得
        size = sphere1.transform.localScale.x;
        //フラグ初期化
        flag= true;
    }

    // Update is called once per frame
    void Update()
    {
        //相対距離の作成
        delVec = sphere1.transform.position - sphere2.transform.position;
        del = delVec.magnitude;

        //当たり判定
        if (del < 0.95f && flag)
        {
            temp = speed1;
            speed1 = speed2;
            speed2 = temp;
            flag= false;
            Debug.Log("SphereHit!");
        }
    }

    private void FixedUpdate()
    {
        //移動処理
        sphere1.transform.position += speed1;
        sphere2.transform.position += speed2;
    }
}
