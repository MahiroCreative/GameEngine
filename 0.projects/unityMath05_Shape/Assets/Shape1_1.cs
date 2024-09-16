using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape1_1 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private Vector3 v3MeshPos = new Vector3(0.0f, 0.0f, 0.0f);
    private float fAngleVelocity = 360.0f / 100.0f;
    private float fObjAngle = 0.0f;

    const int Divide_Num = 20;          // ポリゴン分割数
    const float fRadius = 2.0f;         // 円筒の半径
    const float fLength = 4.0f;         // 円筒の長さ
    // 頂点
    public Vector3[] positions = new Vector3[(Divide_Num + 1) * 2];

    // uv座標
    public Vector2[] uvs = new Vector2[(Divide_Num + 1) * 2];

    // 頂点インデックス（ポリゴンデータ）
    public int[] indices = new int[Divide_Num * 2 * 3];

    // Use this for initialization
    void Start()
    {
        polygon = new Mesh();

        material = GetComponent<Renderer>().material;

        float fAngle = 0.0f;
        float fAngleDelta = 2.0f * Mathf.PI / Divide_Num;
        float tu = 0.0f, dtu = 1.0f / Divide_Num;
        int nIndex = 0;
        for (int i = 0; i <= Divide_Num; i++)
        {
            positions[nIndex] = new Vector3(fRadius * Mathf.Cos(fAngle), fLength / 2.0f,
                                            fRadius * Mathf.Sin(fAngle));
            positions[nIndex + 1] = new Vector3(fRadius * Mathf.Cos(fAngle), -fLength / 2.0f,
                                                fRadius * Mathf.Sin(fAngle));
            uvs[nIndex    ] = new Vector2(tu, 1.0f);
            uvs[nIndex + 1] = new Vector2(tu, 0.0f);
            fAngle += fAngleDelta;
            tu += dtu;
            nIndex += 2;
        }
        nIndex = 0;
        for (int i = 0; i < Divide_Num; i++)
        {
            indices[nIndex] = i * 2;
            indices[nIndex + 1] = i * 2 + 2;
            indices[nIndex + 2] = i * 2 + 1;
            indices[nIndex + 3] = i * 2 + 1;
            indices[nIndex + 4] = i * 2 + 2;
            indices[nIndex + 5] = i * 2 + 3;
            nIndex += 6;
        }
        polygon.vertices = positions;
        polygon.uv = uvs;
        polygon.triangles = indices;
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.DrawMesh(polygon, v3MeshPos,
                          Quaternion.AngleAxis(fObjAngle, new Vector3(1.0f, 0.0f, 0.0f)), material, 0);
    }

    void FixedUpdate()
    {
        fObjAngle += Input.GetAxis("Vertical") * fAngleVelocity;
    }
}
