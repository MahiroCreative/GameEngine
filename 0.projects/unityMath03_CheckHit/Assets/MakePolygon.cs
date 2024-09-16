using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePolygon : MonoBehaviour {
    private Material material;
    private Mesh polygon;

    // 頂点
    public Vector3[] positions = new Vector3[]{
        new Vector3(0.0f, -2.9f, 2.0f),
        new Vector3(3.0f, -2.9f, -2.0f),
        new Vector3(-3.0f, -2.9f, -2.0f)
    };

    // 法線ベクトル
    private Vector3[] normals = new Vector3[]{
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f)
    };

    // 頂点インデックス（ポリゴンデータ）
    private int[] indices = new int[] { 0, 1, 2 };

    // Use this for initialization
    void Start () {
        polygon = new Mesh();

        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;

        polygon.RecalculateBounds();

    }

    // Update is called once per frame
    void Update() {
        Graphics.DrawMesh(polygon, Vector3.zero, Quaternion.identity, material, 0);
    }
}
