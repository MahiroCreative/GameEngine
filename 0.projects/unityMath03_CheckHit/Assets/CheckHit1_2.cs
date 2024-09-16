using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit1_2 : MonoBehaviour
{
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    GameObject target;
    private float fVelocity = 0.1f;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Cube2");
        transform.localScale = new Vector3(2.0f, 1.0f, 1.0f);           // 自身のスケール
        target.transform.localScale = new Vector3(1.5f, 2.0f, 1.0f);    // 相手のスケール
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //インプット値の取得
        float inputX = Input.GetAxis("Horizontal") * fVelocity;
        float inputY = Input.GetAxis("Vertical") * fVelocity;

        //マイフレームCube1の座標を更新
        transform.position = new Vector3(transform.position.x + inputX, transform.position.y + inputY, 0.0f);

        //ターゲットとの相対ベクトルを出している。
        Vector3 v3SubAbs = transform.position - target.transform.position;

        //相対ベクトルを絶対ベクトルに直す。
        //以下意味：
        //それぞれの軸上の相対距離を成分に持つ、ベクトルを作成。
        //マイナスの成分もプラスに直さなければいけないので。
        //絶対値ベクトルと名づける(成分を全てプラスにされたベクトル)
        v3SubAbs = new Vector3(Mathf.Abs(v3SubAbs.x), Mathf.Abs(v3SubAbs.y), Mathf.Abs(v3SubAbs.z));

        //衝突距離を出す。
        //辺の長さの基準が1.0fなので、スケール(倍率)がそのまま1辺の長さと考えられる。
        //そのため、衝突距離はそれぞれの対応した辺の長さを足して２で割ったものなので、
        //以下で、それぞれの成分上での衝突距離が出せる(ベクトルとして)
        Vector3 v3AddScale = ( transform.localScale + target.transform.localScale ) / 2.0f;

        //各成分の当たり判定
        bool isXHit = v3SubAbs.x < v3AddScale.x;
        bool isYHit = v3SubAbs.y < v3AddScale.y;
        bool isZHit = v3SubAbs.z < v3AddScale.z;

        //当たり判定
        if (isXHit && isYHit && isZHit)
        {
            rend.material.color = colorHit;
        }
        else
        {
            rend.material.color = colorNoHit;
        }
    }
}
