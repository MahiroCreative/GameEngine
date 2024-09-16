using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape3_1 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private Vector3 v3MeshPos = new Vector3(0.0f, 0.0f, 0.0f);
    private float fAngleVelocity = 360.0f / 100.0f;
    private float fAngle = 0.0f;

    const int Divide_Num = 20;          // ポリゴン分割数
    const int DataNum = 5;              // データ数
    const int nVertex_Num = (Divide_Num + 1) * DataNum;    // 頂点数
    private Vector2[] SrcPoints = new Vector2[]{    // 形状データ
        new Vector2( 0.0f,  2.0f ),
        new Vector2( 1.0f,  0.5f ),
        new Vector2( 0.5f,  0.5f ),
		new Vector2( 0.5f, -2.0f ),
		new Vector2( 0.0f, -2.0f )
    };

    // 頂点
    public Vector3[] positions = new Vector3[nVertex_Num];

    // uv座標
    public Vector2[] uvs = new Vector2[nVertex_Num];

    // 頂点インデックス（ポリゴンデータ）
    public int[] indices = new int[Divide_Num * (DataNum - 1) * 2 * 3];

    // Use this for initialization
    void Start()
    {
        polygon = new Mesh();

        material = GetComponent<Renderer>().material;

        // 頂点データ
        int nIndex = 0;
        float fAngle;
        float fAngleDelta = 2.0f * Mathf.PI / Divide_Num;
        Vector2 tex;
        tex.y = 1.0f;
        float du = 1.0f / Divide_Num;
        float dv = 1.0f / ( DataNum - 1 );
        for (int i = 0; i < DataNum; i++)
        {
            fAngle = 0.0f;
            tex.x = 0.0f;
            for (int j = 0; j <= Divide_Num; j++)
            {
                positions[nIndex] = new Vector3(SrcPoints[i].x * Mathf.Cos(fAngle),
                                                SrcPoints[i].y,
                                                SrcPoints[i].x * Mathf.Sin(fAngle));
                uvs[nIndex] = tex;
                fAngle += fAngleDelta;
                tex.x += du;
                nIndex++;
            }
            tex.y -= dv;
        }
        // 頂点インデックス
        nIndex = 0;
        for (int i = 0; i < (DataNum - 1); i++)
        {
            for (int j = 0; j < Divide_Num; j++)
            {
                indices[nIndex    ] = i       * (Divide_Num + 1) + j;
                indices[nIndex + 1] = i       * (Divide_Num + 1) + j + 1;
                indices[nIndex + 2] = (i + 1) * (Divide_Num + 1) + j;
                indices[nIndex + 3] = i       * (Divide_Num + 1) + j + 1;
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
