using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform1_1 : MonoBehaviour {
    public Renderer rend;
    public Color colorCube = Color.red;
    Vector3 v3InitialPos;                       // 初期位置
    Quaternion qInitialRot;                     // 初期回転

    // Use this for initialization
    void Start () {
        float fXAbs, fYAbs, fZAbs;

        rend = GetComponent<Renderer>();

        fXAbs = Mathf.Abs(transform.position.x);
        fYAbs = Mathf.Abs(transform.position.y);
        fZAbs = Mathf.Abs(transform.position.z);

        if ((fXAbs > fYAbs) && (fXAbs > fZAbs))
        {
            colorCube = Color.magenta;
        }
        else
        {
            if (fYAbs > fZAbs)
            {
                colorCube = Color.cyan;
            }
            else
            {
                colorCube = Color.yellow;
            }
        }
        v3InitialPos = transform.position;
        qInitialRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float fAngle = 2.0f * Mathf.PI * ((Time.time / 10.0f) % 1); // 角度
        // 回転の行列
        Matrix4x4 matTransform = Matrix4x4.identity;                // 単位行列
        matTransform.m11 = Mathf.Cos(fAngle); matTransform.m12 = -Mathf.Sin(fAngle);
        matTransform.m21 = Mathf.Sin(fAngle); matTransform.m22 =  Mathf.Cos(fAngle);
        transform.position = matTransform * v3InitialPos;     // 変換
        transform.rotation = qInitialRot;                     // 回転初期化
        transform.Rotate(fAngle * 360.0f / ( 2.0f * Mathf.PI ), 0.0f, 0.0f, Space.World);  // 回転
//        transform.Rotate(fAngle * Mathf.Rad2Deg, 0, 0, Space.World);
        rend.material.color = colorCube;
    }
}
