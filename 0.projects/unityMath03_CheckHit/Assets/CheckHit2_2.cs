using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit2_2 : MonoBehaviour {
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    GameObject target;
    CapsuleBasic RefTarget;
    private float fVelocity = 0.1f;
    public float fRadius = 0.5f;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Capsule2");
        RefTarget = target.GetComponent<CapsuleBasic>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //インプット値の取得
        float inputX = Input.GetAxis("Horizontal") * fVelocity;
        float inputY = Input.GetAxis("Vertical") * fVelocity;

        //マイフレームCube1の座標を更新
        transform.position = new Vector3(transform.position.x + inputX, transform.position.y + inputY, 0.0f);

        //相対ベクトル
        Vector3 v3DeltaPos = transform.position - RefTarget.transform.position;

        //衝突する物体の正面ベクトルと相対ベクトルの内積
        float dot = Vector3.Dot(RefTarget.v3Direction, v3DeltaPos);

        //衝突物体の正面ベクトルのマグニチュード
        float mag = Vector3.SqrMagnitude(RefTarget.v3Direction);

        //tは点に向かう法線ベクトルを求めるための係数。
        float t = dot / mag;

        //線分と点の距離を求めるためのtの制限
        if (t < -1.0f) t = -1.0f;                     // tの下限
        if (t >  1.0f) t =  1.0f;                     // tの上限

        //p=at+cで点との最短距離になる線分上の点の位置を求める
        //(※p=at+cは単に求めたい点Pが、図形の中心cからどれだけ離れた点かを表しているだけ)
        Vector3 v3MinPos = RefTarget.v3Direction * t + RefTarget.transform.position;

        //pと自分との距離のマグニチュード
        float fDistSqr = Vector3.SqrMagnitude(v3MinPos - transform.position);

        //衝突距離の計算
        float ar = RefTarget.fRadius + fRadius;       


        // 当たり判定(２乗のまま比較)
        if (fDistSqr < ar * ar)
        {                      
            rend.material.color = colorHit;
        }
        else
        {
            rend.material.color = colorNoHit;
        }
    }
}
