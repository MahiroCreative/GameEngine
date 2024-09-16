using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform5_3 : MonoBehaviour {
    Matrix4x4 matTransform;
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
        Vector3 v3Axis = new Vector3(1.0f, 1.0f, 1.0f);

        fAngle = 2.0f * Mathf.PI * Time.deltaTime / 10.0f;          // 角度

        v3Axis.Normalize();                                         // 軸ベクトル単位化
        qRot.w = Mathf.Cos(fAngle / 2.0f);
        qRot.x = Mathf.Sin(fAngle / 2.0f) * v3Axis.x;
        qRot.y = Mathf.Sin(fAngle / 2.0f) * v3Axis.y;
        qRot.z = Mathf.Sin(fAngle / 2.0f) * v3Axis.z;

        // クォータニオン→行列変換
        matTransform = Matrix4x4.identity;                          // 単位行列

        //行列でのクオータニオン回転
        matTransform.m00 = 1.0f - 2.0f * (qRot.y * qRot.y + qRot.z * qRot.z);
        matTransform.m01 = 2.0f * (qRot.x * qRot.y - qRot.w * qRot.z);
        matTransform.m02 = 2.0f * (qRot.x * qRot.z + qRot.w * qRot.y);
        matTransform.m10 = 2.0f * (qRot.x * qRot.y + qRot.w * qRot.z);
        matTransform.m11 = 1.0f - 2.0f * (qRot.x * qRot.x + qRot.z * qRot.z);
        matTransform.m12 = 2.0f * (qRot.y * qRot.z - qRot.w * qRot.x);
        matTransform.m20 = 2.0f * (qRot.x * qRot.z - qRot.w * qRot.y);
        matTransform.m21 = 2.0f * (qRot.y * qRot.z + qRot.w * qRot.x);
        matTransform.m22 = 1.0f - 2.0f * (qRot.x * qRot.x + qRot.y * qRot.y);

        transform.position = matTransform * transform.position;     // 変換

        transform.rotation = qRot * transform.rotation;             // 回転
        rend.material.color = colorCube;
    }
}
