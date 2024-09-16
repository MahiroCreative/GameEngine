using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform4_2 : MonoBehaviour {
    //変数と初期値の作成
    Quaternion qInitialRot;                     
    public int nDepth = 0;
    public Vector3 v3BasePos = new Vector3( 2.0f, 0.0f, 0.0f );

    // Use this for initialization
    void Start()
    {
        //現在の回転度合い
        qInitialRot = transform.rotation;
        //色の濃さの設定
        float fBright = (20.0f - (float)nDepth) / 20.0f;
        //色合を作成
        GetComponent<Renderer>().material.color = new Color(0.9f + fBright * 0.1f, fBright, 0.7f + fBright * 0.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //親オブジェクトが存在しているときだけ実行
        if (transform.parent)
        {
            //現在の深度から回転度合を作成
            float fPosAngle = nDepth * 2.0f * Mathf.PI / 25.0f *
                              Mathf.Sin(2.0f * Mathf.PI * ((Time.time / 6.0f) % 1));
            //回転軸の設定
            Vector3 v3RotAxis = new Vector3(-0.6f, -0.5f, 0.3f);
            //上記で作成した回転軸を基準に回転量を表すクオータニオンを作成
            Quaternion qRot = Quaternion.AngleAxis(fPosAngle * 360.0f / (2.0f * Mathf.PI), v3RotAxis);
            //座標にクォータニオンを掛けて、回転後の座標を作成
            Vector3 v3RelPos = qRot * v3BasePos;
            //現在の座標の更新(上記までで作ったのは、親の位置からどれだけズレてるかの座標)
            transform.position = transform.parent.position + v3RelPos;
            //親を正面に捉えるべく回転
            transform.LookAt(transform.parent.position, new Vector3(0.0f, 1.0f, 0.0f));
        }
    }
}
