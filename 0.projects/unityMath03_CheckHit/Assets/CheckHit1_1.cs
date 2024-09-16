using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit1_1 : MonoBehaviour
{
    /*変数の作成*/
    public Renderer rend;//レンダラー
    //色
    private Color colorNoHit = Color.cyan;
    private Color colorHit = Color.red;
    //ターゲット
    GameObject target;
    //移動速度
    private float fVelocity = 0.1f;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Cube2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //インプット値の取得
        float inputX = Input.GetAxis("Horizontal") * fVelocity;
        float inputY = Input.GetAxis("Vertical"  ) * fVelocity;

        //マイフレームCube1の座標を更新
        transform.position = new Vector3(transform.position.x + inputX ,transform.position.y + inputY ,0.0f);

        //各座標方向で当たっている可能性があるかの判定
        //Absは絶対値を出してる。
        bool isXHit = Mathf.Abs(transform.position.x - target.transform.position.x) < 1.0f;
        bool isYHit = Mathf.Abs(transform.position.y - target.transform.position.y) < 1.0f;
        bool isZHit = Mathf.Abs(transform.position.z - target.transform.position.z) < 1.0f;


        //当たり判定(全軸で当たっている可能性がある場合は当たっている)
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
