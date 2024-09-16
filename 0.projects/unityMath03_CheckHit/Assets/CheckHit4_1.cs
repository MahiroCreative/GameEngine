using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit4_1 : MonoBehaviour
{
    //変数の作成
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    GameObject target;
    private const float fVelocity = 0.1f;
    
    /*当たり判定用の変数作成*/
    MakePolygon TargetPoly;
    Vector3 v3TriVec0, v3TriVec1, v3TriVec2;
    Vector3 v3HitVec0, v3HitVec1, v3HitVec2;
    float fCross0, fCross1, fCross2;
    bool bHit;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0.0f, -2.5f, 0.0f);
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*移動操作*/
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * fVelocity,transform.position.y,transform.position.z + Input.GetAxis("Vertical") * fVelocity);
       
        /*三角形のオブジェクトのスクリプトを取得している*/
        TargetPoly = target.GetComponent<MakePolygon>();

        // 三角形サイクルベクトル
        v3TriVec0 = TargetPoly.positions[1] - TargetPoly.positions[0];
        v3TriVec1 = TargetPoly.positions[2] - TargetPoly.positions[1];
        v3TriVec2 = TargetPoly.positions[0] - TargetPoly.positions[2];

        // 三角形頂点からターゲットへのベクトル
        v3HitVec0 = transform.position - TargetPoly.positions[0];
        v3HitVec1 = transform.position - TargetPoly.positions[1];
        v3HitVec2 = transform.position - TargetPoly.positions[2];

        // それぞれの外積(のy成分)
        fCross0 = v3TriVec0.z * v3HitVec0.x - v3TriVec0.x * v3HitVec0.z;
        fCross1 = v3TriVec1.z * v3HitVec1.x - v3TriVec1.x * v3HitVec1.z;
        fCross2 = v3TriVec2.z * v3HitVec2.x - v3TriVec2.x * v3HitVec2.z;

        //当たっているかのフラグ変数
        bHit = false;

        /*全て同じ側にいるかの判定*/
        if (fCross0 >= 0.0f)
        {
            if ((fCross1 >= 0.0f) && (fCross2 >= 0.0f))
            {
                bHit = true;
            }
        }
        else
        {
            if ((fCross1 < 0.0f) && (fCross2 < 0.0f))
            {
                bHit = true;
            }
        }

        /*当たっていた時の処理*/
        if (bHit)
        {
            rend.material.color = colorHit;
        }
        else
        {
            rend.material.color = colorNoHit;
        }
    }
}
