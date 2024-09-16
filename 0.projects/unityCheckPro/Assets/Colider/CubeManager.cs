using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    float del;
    GameObject cube1, cube2;
    Vector3 speed1, speed2, temp;
    Transform c1T, c2T;
    bool flag;


    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの取得
        cube1 = GameObject.Find("Cube1");
        cube2 = GameObject.Find("Cube2");
        //反転用
        temp = new Vector3();

        //互いの方向へのベクトル成分の作成
        speed1 = new Vector3();
        speed1 = cube2.transform.position - cube1.transform.position;//sphere1からsphere2へのベクトル
        speed1 = speed1.normalized;//単位ベクトル化
        speed1 = speed1 / 50;//速すぎるので1/50に。
        speed2 = new Vector3();
        speed2 = cube1.transform.position - cube2.transform.position;//sphere2からsphere1へのベクトル
        speed2 = speed2.normalized;//単位ベクトル化
        speed2 = speed2 / 50;//速すぎるので1/50に。
        //二つのオブジェクトのトランスフォームの確保
        c1T = cube1.transform;
        c2T = cube2.transform;

        //当たり判定
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //当たり判定
        flag = BoxCollision.CheckCubeCol(c1T,c2T);

        //反転処理
        if (flag == true)
        {
            temp = speed1;
            speed1 = speed2;
            speed2 = temp;
            flag = false;
            Debug.Log("hit");
        }
    }
    private void FixedUpdate()
    {
        //移動処理
        cube1.transform.position += speed1;
        cube2.transform.position += speed2;
    }
}