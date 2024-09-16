using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform6_1 : MonoBehaviour {
    public Renderer rend;
    public Color colorCube = Color.red;
    Vector3 v3InitialPos;                       // 初期位置
    Quaternion qInitialRot;                     // 初期回転
    float t = 0.01f;

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
        //変数
        Quaternion qRot_p, qRot_r;
        Quaternion qRot1, qRot2;
        //軸ベクトルの作成
        Vector3 v3Axis1 = new Vector3(-1.0f, 1.0f, 1.0f);
        Vector3 v3Axis2 = new Vector3(1.0f, -1.0f, -0.9f);
        //角度等の設定
        float fAngle = 0.0f;
        //float t;
        float fPhaseTime;
        //fAngle = Mathf.PI / 3.0f;                                   // 角度
        fAngle = Mathf.PI / 1.5f;                                   // 角度

        //それぞれの回転の回転クォータニオンの作成
        qRot1 = Quaternion.AngleAxis(fAngle * 360.0f / (2.0f * Mathf.PI), v3Axis1); // クォータニオン1
        qRot2 = Quaternion.AngleAxis(fAngle * 360.0f / (2.0f * Mathf.PI), v3Axis2); // クォータニオン2

        //何秒ごとに回転するか
        fPhaseTime = Time.fixedTime * 0.5f;

        // 三角波
        t = Mathf.Abs(fPhaseTime - Mathf.Floor(fPhaseTime) - 0.5f) * 2.0f;

        // 球面線形補間（Unity標準）
        //qRot_p = Quaternion.Slerp(qRot1, qRot2, t);
        //qRot_p = Quaternion.Lerp(qRot1, qRot2, t);
        
        float q1t, q2t;
        float fDotProduct;//何らかの内積
        float fTheta;//Θ

        //内積の計算(クォータニオンの内積)
        fDotProduct = qRot1.x * qRot2.x + qRot1.y * qRot2.y + qRot1.z * qRot2.z + qRot1.w * qRot2.w;

        //角度の補完をする
        //内積の結果が0を下回れば、なす角が90度を超えている。
        if( fDotProduct < 0.0f)
        {
            qRot1 = new Quaternion(-qRot1.x,-qRot1.y,-qRot1.z,-qRot1.w);
            fDotProduct = -fDotProduct;//内積がマイナスになってるので、プラスに戻す
        }

        //角度の計算
        //アークコサインにクオータニオンの内積を渡すと、
        //球面線形補完に必要なΘが生まれる
        fTheta = Mathf.Acos(fDotProduct);

        //それぞれのパラメータの計算
        //球形の場合は、sinΘをsinΘで和って、分子のΘをパラメータでずらす
        q1t = Mathf.Sin(fTheta * (1.0f - t)) / Mathf.Sin(fTheta);
        q2t = Mathf.Sin(fTheta * t) / Mathf.Sin(fTheta);

        //上記までで出来上がったパラメータを
        //そらぞれの座標に掛けたて、足してる
        qRot_p.x = q1t * qRot1.x + q2t * qRot2.x;
        qRot_p.y = q1t * qRot1.y + q2t * qRot2.y;
        qRot_p.z = q1t * qRot1.z + q2t * qRot2.z;
        qRot_p.w = q1t * qRot1.w + q2t * qRot2.w;

        // 球面線形補間（Unity標準）
        //姿勢の回転
        qRot_r = Quaternion.Slerp(qRot1, qRot2, t);

        transform.position = qRot_p * v3InitialPos;            // 変換
        transform.rotation = qRot_r * qInitialRot;             // 回転
        rend.material.color = colorCube;
    }
}
