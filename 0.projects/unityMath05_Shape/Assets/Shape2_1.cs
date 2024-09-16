using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape2_1 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private Vector3 v3MeshPos = new Vector3(0.0f, 0.0f, 0.0f);
    private float fAngleVelocity = 360.0f / 100.0f;
    private float fAngle = 0.0f;

    const int Divide_Num = 20;          // ポリゴン分割数
    const int nVertex_Num = (Divide_Num + 1) * (Divide_Num / 2 + 1);    // 頂点数
    const float fRadius = 3.0f;         // 球の半径
    // 頂点
    public Vector3[] positions = new Vector3[nVertex_Num];

    // uv座標
    public Vector2[] uvs = new Vector2[nVertex_Num];

    // 頂点インデックス（ポリゴンデータ）
    public int[] indices = new int[Divide_Num * (Divide_Num / 2) * 2 * 3];

    // Use this for initialization
    void Start()
    {
        polygon = new Mesh();

        material = GetComponent<Renderer>().material;

        // 頂点データ
        int nIndex = 0;
        float fTheta = 0.0f;
        float fPhi;
        float fAngleDelta = 2.0f * Mathf.PI / Divide_Num;
        Vector2 tex;
        float dt = 1.0f / Divide_Num;
        tex.y = 1.0f;
        for (int i = 0; i <= Divide_Num / 2; i++)
        {
            fPhi = 0.0f;
            tex.x = 0.0f;
            for (int j = 0; j <= Divide_Num; j++)
            {
                positions[nIndex] = new Vector3(fRadius * Mathf.Sin(fTheta) * Mathf.Cos(fPhi),
                                                fRadius * Mathf.Cos(fTheta),
                                                fRadius * Mathf.Sin(fTheta) * Mathf.Sin(fPhi));
                uvs[nIndex] = tex;
                fPhi += fAngleDelta;
                tex.x += dt;
                nIndex++;
            }
            fTheta += fAngleDelta;
            tex.y -= 2.0f * dt;
        }
        // 頂点インデックス
        nIndex = 0;
        for (int i = 0; i < Divide_Num / 2; i++)
        {
            for (int j = 0; j < Divide_Num; j++)
            {
                indices[nIndex] = i * (Divide_Num + 1) + j;
                indices[nIndex + 1] = i * (Divide_Num + 1) + j + 1;
                indices[nIndex + 2] = (i + 1) * (Divide_Num + 1) + j;
                indices[nIndex + 3] = i * (Divide_Num + 1) + j + 1;
                indices[nIndex + 4] = (i + 1) * (Divide_Num + 1) + j + 1;
                indices[nIndex + 5] = (i + 1) * (Divide_Num + 1) + j;
                nIndex += 6;
            }
        }
        polygon.vertices = positions;
        polygon.uv = uvs;
        polygon.triangles = indices;
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.DrawMesh(polygon, v3MeshPos,
                          Quaternion.AngleAxis(fAngle, new Vector3(1.0f, 0.0f, 0.0f)), material, 0);
    }

    void FixedUpdate()
    {
        fAngle += Input.GetAxis("Vertical") * fAngleVelocity;
    }
}
