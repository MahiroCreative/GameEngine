using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit5_3 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private const float fFloorSize = 10.0f;
    private Vector3 v3Vec1 = new Vector3(fFloorSize / 2.0f, 0.0f, 0.0f);
    private Vector3 v3Vec2 = new Vector3(0.0f, 0.0f, fFloorSize / 2.0f);
    private Vector3 v3GroundNormal = new Vector3(0.0f, 1.0f, 0.0f);
    private const float fVelocity = 0.1f;

    // 頂点
    public Vector3[] positions = new Vector3[]{
        new Vector3(-fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3(-fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
    };

    // 法線ベクトル
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
        material = GetComponent<Renderer>().material;
        material.color = new Color(0.0f, 0.0f, 1.0f);
        polygon = new Mesh();

        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;

        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
        // 地面の傾斜変更
        v3Vec1 = new Vector3(fFloorSize / 2.0f,
                             2.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 5.0f),
                             3.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 10.0f));
        v3Vec2 = new Vector3(5.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 12.0f),
                             0.8f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 7.0f) + 0.7f,
                             fFloorSize / 2.0f);

        // 基底ベクトル計算
        float bx = transform.position.x + Input.GetAxis("Horizontal") * fVelocity;
        float bz = transform.position.z + Input.GetAxis("Vertical") * fVelocity;

        //外積の計算
        //外積求めたそれぞれの成分が、面の方程式の係数になる。
        Vector3 v3Normal = Vector3.Cross(v3Vec1, v3Vec2);

        //方程式を解いて、y座標を出す式にする。
        float by = (-v3Normal.x * bx - v3Normal.z * bz) / v3Normal.y + 0.5f;

        //求めた値を入れる
        transform.position = new Vector3(bx, by, bz);
    }
}
