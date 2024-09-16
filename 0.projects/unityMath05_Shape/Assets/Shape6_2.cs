using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape6_2 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private Vector3 v3MeshPos = new Vector3(0.0f, 0.0f, 0.0f);
    private float fAngleVelocity = 360.0f / 100.0f;
    private float fAngle = 0.0f;

    const int Point_Num = 40;          // 通過点数
    const int Divide_Num = 20;         // 分割数
    const float fLineSize = 0.5f;      // 線幅
    const int nVertex_Num = Point_Num * (Divide_Num + 1);    // 頂点数
    // 通過点
    public Vector3[] points = new Vector3[Point_Num];

    // 頂点
    public Vector3[] positions = new Vector3[nVertex_Num];

    // uv座標
    public Vector2[] uvs = new Vector2[nVertex_Num];

    // 頂点インデックス（ポリゴンデータ）
    public int[] indices = new int[(Point_Num - 1) * Divide_Num * 2 * 3];

    // Use this for initialization
    void Start()
    {
        polygon = new Mesh();

        material = GetComponent<Renderer>().material;

        // 通過点データ
        for (int i = 0; i < Point_Num; i++)
        {
            points[i] = new Vector3(5.0f * (float)(i - Point_Num / 2.0f) / (Point_Num / 2.0f),
                                    3.0f * Mathf.Sin(2.0f * Mathf.PI * (float)i / Point_Num),
                                    2.0f * Mathf.Sin(2.0f * Mathf.PI * 0.6f * (float)i / Point_Num));
        }

        // 頂点データ
        int nIndex = 0;
        float fLineAngleDelta = 2.0f * Mathf.PI / Divide_Num;
        for (int i = 0; i < Point_Num; i++)
        {
            Vector3 v3Forward;
            if (i < Point_Num - 1)
            {
                v3Forward = points[i + 1] - points[i];      // 通常のフォワード
            }
            else
            {
                v3Forward = points[i] - points[i - 1];      // 端のフォワード
            }
            Vector3 v3SideS1 = new Vector3(-v3Forward.z, 0, v3Forward.x);   // 法線ベクトル１
            Vector3 v3SideS2 = Vector3.Cross(v3Forward, v3SideS1);          // 法線ベクトル２
            v3SideS1.Normalize();
            v3SideS2.Normalize();
            float fLineAngle = 0.0f;
            for (int j = 0; j <= Divide_Num; j++)
            {
                positions[nIndex] = points[i]
                                  + fLineSize * Mathf.Cos(fLineAngle) * v3SideS1
                                  + fLineSize * Mathf.Sin(fLineAngle) * v3SideS2;
                uvs[nIndex] = new Vector2(0.0f, 0.0f);
                fLineAngle += fLineAngleDelta;
                nIndex++;
            }
        }
        // 頂点インデックス
        nIndex = 0;
        for (int i = 0; i < Point_Num - 1; i++)
        {
            for (int j = 0; j < Divide_Num; j++)
            {
                indices[nIndex    ] = i       * (Divide_Num + 1) + j;
                indices[nIndex + 1] = i       * (Divide_Num + 1) + j + 1;
                indices[nIndex + 2] = (i + 1) * (Divide_Num + 1) + j + 1;
                indices[nIndex + 3] = (i + 1) * (Divide_Num + 1) + j + 1;
                indices[nIndex + 4] = (i + 1) * (Divide_Num + 1) + j;
                indices[nIndex + 5] = i       * (Divide_Num + 1) + j;
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
