using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit5_1 : MonoBehaviour
{
    /*変数の作成*/
    private Material material;
    private Mesh polygon;
    private const float fFloorSize = 10.0f;
    private Vector3 v3Vec1 = new Vector3(fFloorSize / 2.0f, 0.0f, 0.0f);//x方向の傾斜
    private Vector3 v3Vec2 = new Vector3(0.0f, 0.0f, fFloorSize / 2.0f);//y方向の傾斜
    private Vector3 v3GroundNormal = new Vector3(0.0f, 1.0f, 0.0f);
    private const float fVelocity = 0.1f;

    /*床を作るための変数の作成*/
    // フロアの頂点
    public Vector3[] positions = new Vector3[]{
        new Vector3(-fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3(-fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
    };
    // フロア法線ベクトル
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
        /*床作ってる処理*/
        material = GetComponent<Renderer>().material;
        material.color = new Color(0.0f, 0.0f, 1.0f);
        polygon = new Mesh();

        //床作ってる
        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;

        /*Cubeの位置の初期化*/
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //床動かしてる
        positions[0] = -v3Vec1 + v3Vec2;
        positions[1] =  v3Vec1 + v3Vec2;
        positions[2] = -v3Vec1 - v3Vec2;
        positions[3] =  v3Vec1 - v3Vec2;
        for (int i = 0; i < 4; i++) normals[i] = v3GroundNormal;
        polygon.vertices = positions;
        polygon.normals = normals;
        Graphics.DrawMesh(polygon, Vector3.zero, Quaternion.identity, material, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*地面の傾斜変更*/
        //X方向(0.5fは傾きの調整値)
        v3Vec1 = new Vector3(fFloorSize / 2.0f, 2.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 5.0f), 0.0f);
        //Y方向(0.5fは傾きの調整値)
        v3Vec2 = new Vector3(0.0f,0.8f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 7.0f) + 0.7f, fFloorSize / 2.0f);

        /*乗ってる自分自身の座標の計算*/
        //単純な移動距離
        float bx = transform.position.x + Input.GetAxis("Horizontal") * fVelocity;
        float bz = transform.position.z + Input.GetAxis("Vertical") * fVelocity;

        //床に沿った位置の調整
        //[X方向の傾きから出した値]*bx + [X方向の傾きから出した値]*bz + 調整値(傾きの調整値)
        float by = (v3Vec1.y  / v3Vec1.x) * bx + (v3Vec2.y  / v3Vec2.z) * bz + 0.5f;

        //代入
        transform.position = new Vector3(bx, by, bz);
    }
}
