using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit4_2 : MonoBehaviour
{
    //変数作成
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    GameObject target;
    private const float fVelocity = 0.1f;
    //当たり判定用の変数
    MakePolygon TargetPoly;
    Vector3 v3TriVec0, v3TriVec1, v3TriVec2;
    Vector3 v3HitVec0, v3HitVec1, v3HitVec2;
    float fCross0, fCross1, fCross2;
    float fDot;
    bool bHit;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(-2.0f, -2.5f, 0.0f);
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*移動処理*/
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * fVelocity,transform.position.y,transform.position.z + Input.GetAxis("Vertical") * fVelocity);

        /*三角形との当たり判定*/
        //スクリプト取得
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
        bHit = false;
        //当たり判定
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



        /*進入禁止処理*/
        // サイクルベクトル単位化
        v3TriVec0.Normalize();
        v3TriVec1.Normalize();
        v3TriVec2.Normalize();

        /*どの辺に一番近い位置で当たっているかを判定*/
        //外積の大きさが一番小さい位置が一番近い。
        if (bHit)
        {
            //辺0に一番近い。
            //片方を単位ベクトルかしておくと、外積の大きさは|b|sinΘになり、
            //これは、点と辺の距離に等しいので判定できる。
            if ((Mathf.Abs(fCross0) <= Mathf.Abs(fCross1)) &&(Mathf.Abs(fCross0) <= Mathf.Abs(fCross2)))
            {
                /*当たった辺まで移動させる*/
                //片方が単位ベクトルなので、内積は|b|cosΘ
                //|b|cosΘは、判定点から辺へ垂線を下した位置に等しい。
                fDot = Vector3.Dot(v3TriVec0, v3HitVec0);//長さを出す
                //当たった軸の原点から当たった点までのベクトルを作成して、その位置に戻す。
                transform.position = new Vector3(v3TriVec0.x * fDot + TargetPoly.positions[0].x,transform.position.y,v3TriVec0.z * fDot + TargetPoly.positions[0].z);
            }
            else//辺1or辺2に近い
            {
                // 辺１に一番近い
                if (Mathf.Abs(fCross1) <= Mathf.Abs(fCross2))
                {
                    
                    fDot = Vector3.Dot(v3TriVec1, v3HitVec1);
                    transform.position = new Vector3(v3TriVec1.x * fDot + TargetPoly.positions[1].x,transform.position.y,v3TriVec1.z * fDot + TargetPoly.positions[1].z);
                }
                else// 辺２に一番近い
                {
                    fDot = Vector3.Dot(v3TriVec2, v3HitVec2);
                    transform.position = new Vector3(v3TriVec2.x * fDot + TargetPoly.positions[2].x,transform.position.y,v3TriVec2.z * fDot + TargetPoly.positions[2].z);
                }
            }
        }

        /*色替え*/
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
