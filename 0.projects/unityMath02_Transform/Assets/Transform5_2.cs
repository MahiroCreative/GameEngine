using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform5_2 : MonoBehaviour {
    public Renderer rend;
    public Color colorCube = Color.red;
    private float fAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion qRot;
        Quaternion qPos;
        Vector3 v3Pos;
        Vector3 v3Axis = new Vector3(1.0f, 1.0f, 1.0f);

        fAngle = 2.0f * Mathf.PI * Time.deltaTime / 10.0f;          // 角度

        v3Axis.Normalize();                                         // 軸ベクトル単位化
        qRot.w = Mathf.Cos(fAngle / 2.0f);
        qRot.x = Mathf.Sin(fAngle / 2.0f) * v3Axis.x;
        qRot.y = Mathf.Sin(fAngle / 2.0f) * v3Axis.y;
        qRot.z = Mathf.Sin(fAngle / 2.0f) * v3Axis.z;

        // クォータニオンによる回転
        v3Pos = transform.position;
        qPos.x = v3Pos.x;
        qPos.y = v3Pos.y;
        qPos.z = v3Pos.z;
        qPos.w = 1.0f;
        qPos = qRot * qPos * new Quaternion(-qRot.x, -qRot.y, -qRot.z, qRot.w);// Quaternion.Inverse(qRot);
        v3Pos.x = qPos.x;
        v3Pos.y = qPos.y;
        v3Pos.z = qPos.z;
        transform.position = v3Pos;     // 変換
//        transform.position = qRot * transform.position;     // 変換
        transform.rotation = qRot * transform.rotation;             // 回転
        rend.material.color = colorCube;
    }
}
