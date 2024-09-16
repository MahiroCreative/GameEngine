using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform6_2 : MonoBehaviour {
    public Renderer rend;
    public Color colorCube = Color.red;
    Vector3 v3InitialPos;                       // 初期位置
    Quaternion qInitialRot;                     // 初期回転

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
        v3InitialPos = transform.position;
        qInitialRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion qRot_p, qRot_r;
        Quaternion qRot1, qRot2;
        Vector3 v3Axis1 = new Vector3(-1.0f, 1.0f, 1.0f), v3Axis2 = new Vector3(1.0f, -1.0f, -0.9f);
        float fAngle = 0.0f;
        float fDotProduct;
        float q1t, q2t;
        float fTheta;
        float t;
        float fPhaseTime;

//        fAngle = Mathf.PI / 2.1f;                                   // 角度
        fAngle = Mathf.PI / 1.5f;                                   // 角度

        qRot1 = Quaternion.AngleAxis(fAngle * 360.0f / (2.0f * Mathf.PI), v3Axis1); // クォータニオン1
        qRot2 = Quaternion.AngleAxis(fAngle * 360.0f / (2.0f * Mathf.PI), v3Axis2); // クォータニオン2

        fPhaseTime = Time.fixedTime * 0.5f;
        t = Mathf.Abs(fPhaseTime - Mathf.Floor(fPhaseTime) - 0.5f) * 2.0f;  // 三角波

        // 時前でのSlerp
        fDotProduct = qRot1.x * qRot2.x + qRot1.y * qRot2.y + qRot1.z * qRot2.z +
                      qRot1.w * qRot2.w;      // 内積計算
        if (fDotProduct < 0.0f)
        {                   // 内積を＋に収める
            qRot1 = new Quaternion( -qRot1.x, -qRot1.y, -qRot1.z, -qRot1.w );
            fDotProduct = -fDotProduct;
        }
        if (fDotProduct > 1.0f)                 // 内積の計算誤差対策
        {                           			// 同じ場合、後ろと同じに
            q1t = 0.0f;
            q2t = 1.0f;
        }
        else
        {                                       // 球面線形補間
            fTheta = Mathf.Acos(fDotProduct);            // 角度計算
            if (fTheta < 0.00001f)
            {               // 同じ場合、後ろと同じに
                q1t = 0.0f;
                q2t = 1.0f;
            }
            else
            {
                q1t = Mathf.Sin(fTheta * (1.0f - t)) / Mathf.Sin(fTheta);
                q2t = Mathf.Sin(fTheta * t) / Mathf.Sin(fTheta);
            }
        }
        qRot_p.x = q1t * qRot1.x + q2t * qRot2.x;
        qRot_p.y = q1t * qRot1.y + q2t * qRot2.y;
        qRot_p.z = q1t * qRot1.z + q2t * qRot2.z;
        qRot_p.w = q1t * qRot1.w + q2t * qRot2.w;
        qRot_r = Quaternion.Slerp(qRot1, qRot2, t);               // 球面線形補間（Unity標準）

        transform.position = qRot_p * v3InitialPos;             // 変換
        transform.rotation = qRot_r * qInitialRot;              // 回転
        rend.material.color = colorCube;
    }
}
