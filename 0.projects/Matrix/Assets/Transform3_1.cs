using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform3_1 : MonoBehaviour
{
    //マテリアルとは単に色のこと(ｼｪｰﾀﾞ)
    private Material material;
    private Material material2;
    //メッシュとはポリゴンのこと
    private Mesh polygon;
    //いったん放置
    private const float fFloorSize = 10.0f;
    private Vector3 v3Vec1 = new Vector3(fFloorSize / 2.0f, 0.0f, 0.0f);
    private Vector3 v3Vec2 = new Vector3(0.0f, 0.0f, fFloorSize / 2.0f);
    private Vector3 v3GroundNormal = new Vector3(0.0f, 1.0f, 0.0f);
    private float fAngle = Mathf.PI / 2.0f;

    //作成するオブジェクトの頂点
    public Vector3[] positions = new Vector3[]{
        new Vector3(-fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3(-fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
    };

    //それぞの頂点の法線ベクトル(作った段階ではy軸方向が正面)
    //法線ベクトルは単位行列じゃないといけないので、全部単位行列にしてます。
    private Vector3[] normals = new Vector3[]{
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
    };

    // 頂点インデックス（ポリゴンデータ）
    private int[] indices = new int[] { 0, 1, 2, 1, 3, 2 };

    // Use this for initialization
    void Start()
    {
        /*アタッチした物体を青くして拡大*/
        //色付け
        material = GetComponent<Renderer>().material;
        material.color = new Color(0.0f, 0.0f, 1.0f);//blue

        //位置決定
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        transform.localScale = new Vector3(2.0f, 1.0f, 6.0f);


        /*床のポリゴンの作成*/
        ////メッシュの作成(形を作る)
        polygon = new Mesh();
        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;
        //色
        //material2.color = new Color(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //頂点の位置を変えることで傾きを作っている。
        positions[0] = -v3Vec1 + v3Vec2;
        positions[1] = v3Vec1 + v3Vec2;
        positions[2] = -v3Vec1 - v3Vec2;
        positions[3] = v3Vec1 - v3Vec2;

        //法線ベクトルの初期化処理
        for (int i = 0; i < 4; i++) normals[i] = v3GroundNormal;
        //新しい頂点の座標の挿入
        polygon.vertices = positions;
        //新しい法線ベクトルの挿入(初期化)
        polygon.normals = normals;
        //メッシュの描画
        Graphics.DrawMesh(polygon, Vector3.zero, Quaternion.identity, material2, 0);
    }

    void FixedUpdate()
    {
        // 地面の傾斜変更(頂点の変更)
        v3Vec1 = new Vector3(fFloorSize / 2.0f, 2.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 5.0f), 0.0f);
        v3Vec2 = new Vector3(0.0f, 0.8f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 7.0f) + 0.7f, fFloorSize / 2.0f);

        ////// 基底ベクトル計算
        /*斜面上での運動(入力値により動く)*/
        fAngle += Input.GetAxis("Horizontal") * 0.1f;
        ////斜面に合わせた座標空間に変換できる基底ベクトルの作成
        Vector3 v3Up = Vector3.Cross(v3Vec2, v3Vec1);//外積
        Vector3 v3Forward = new Vector3(Mathf.Cos(fAngle), 0.0f, Mathf.Sin(fAngle));//仮のｚ軸
        Vector3 v3Side = Vector3.Cross(v3Up, v3Forward);//仮のｚ軸から外積
        v3Forward = Vector3.Cross(v3Side, v3Up);//正しいz軸を出す
        //上記で作成した座標上に変換する(傾ける)
        transform.LookAt(v3Forward, v3Up);
    }
}
