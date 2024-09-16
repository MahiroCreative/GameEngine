using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit2_1 : MonoBehaviour {
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    GameObject target;
    private float fVelocity = 0.1f;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Sphere2");
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
        Vector3 v3Delta = transform.position - target.transform.position;

        //マグニチュード(三平方の定理のルートない版)
        //ルートの計算は重くてやりたくないので、マグニチュードで条件判定する。
        float fDistanceSq = v3Delta.x * v3Delta.x + v3Delta.y * v3Delta.y + v3Delta.z * v3Delta.z;

        //当たり判定
        //マグニチュードなので、衝突距離(右辺)も二乗
        if (fDistanceSq < (1.0f * 1.0f))
        {
            rend.material.color = colorHit;
        }
        else
        {
            rend.material.color = colorNoHit;
        }
    }
}
