using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape5_2 : MonoBehaviour {
    private Material material;
    private Mesh polygon;
    private Vector3 v3MeshPos = new Vector3(0.0f, 0.0f, 0.0f);
    private float fAngleVelocity = 360.0f / 100.0f;
    private float fAngle = 0.0f;

    const int Divide_Num = 20;          // ポリゴン分割数
    const int nVertex_Num = (Divide_Num + 1) * (Divide_Num + 1);    // 頂点数
    const float fFloorSize = 10.0f;         // 床の半径
    const float fWaveLength = fFloorSize;   // 波長
    const float fWaveAmp = 1.0f;            // 振幅
    const float fPeriod = 2000.0f;          // 周期
    // 頂点
    public Vector3[] positions = new Vector3[nVertex_Num];

    // uv座標
    public Vector2[] uvs = new Vector2[nVertex_Num];

    // 頂点インデックス（ポリゴンデータ）
    public int[] indices = new int[Divide_Num * Divide_Num * 2 * 3];

    // Use this for initialization
    void Start()
    {
        polygon = new Mesh();

        material = GetComponent<Renderer>().material;

        // 頂点データ
        int nIndex = 0;
        float x, z;
        Vector2 tex;
        z = fFloorSize / 2.0f;
        float dx = fFloorSize / Divide_Num;
        tex.y = 1.0f;
        float du = 1.0f / Divide_Num;
        for (int i = 0; i <= Divide_Num; i++)
        {
            x = -fFloorSize / 2.0f;
            tex.x = 0.0f;
            for (int j = 0; j <= Divide_Num; j++)
            {
                positions[nIndex] = new Vector3(x, 0.0f, z);
                uvs[nIndex] = tex;
                x += dx;
                tex.x += du;
                nIndex++;
            }
            z -= dx;
            tex.y -= du;
        }
        // 頂点インデックス
        nIndex = 0;
        for (int i = 0; i < Divide_Num; i++)
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
        float fMiliSec = (float)System.DateTime.Now.Second * 1000.0f
                       + (float)System.DateTime.Now.Millisecond;
        for (int i = 0; i < (Divide_Num + 1) * (Divide_Num + 1); i++)
        {
            float x = positions[i].x;
            float z = positions[i].z;
            float fPhase = fMiliSec / fPeriod - (x + z) / fWaveLength;
            positions[i].y = fWaveAmp * Mathf.Sin(2.0f * Mathf.PI * fPhase);
        }
        polygon.vertices = positions;
        fAngle += Input.GetAxis("Vertical") * fAngleVelocity;
    }
}
