using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit3_1 : MonoBehaviour
{
    //変数の宣言
    public Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    public Color colorPararrelNoHit = Color.yellow;
    public Color colorPararrelHit = Color.magenta;
    GameObject target;
    CapsuleBasic RefTarget;//ユーザ定義クラス
    private float fVelocity = 0.1f;
    public Vector3 v3Direction; // 方向ベクトル
    public float fRadius = 0.5f;
    private Quaternion qRot;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        target = GameObject.Find("Capsule2");
        RefTarget = target.GetComponent<CapsuleBasic>();//ターゲットの持つクラス
        target.transform.position = new Vector3(-1.0f, 2.0f, 0.3f);
        qRot = Quaternion.AngleAxis(30.0f, new Vector3(1.0f, 1.0f, 1.0f));
        v3Direction = new Vector3(0.0f, 0.5f, 0.0f);
        v3Direction = qRot * v3Direction;//方向ベクトルの回転
        transform.rotation = qRot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*数値の作成1*/
        //計算用の変数
        float s, t;
        //入力による移動
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * fVelocity, transform.position.y + Input.GetAxis("Vertical") * fVelocity, 0.0f);
        //ターゲットと自分の相対ベクトルの作成
        Vector3 v3DeltaPos = RefTarget.transform.position - transform.position;
        //行列の掛け算が出来るように4つめの要素を増やす？（なんで0なんだろ...）
        Vector4 v4DeltaPos = new Vector4(v3DeltaPos.x, v3DeltaPos.y, v3DeltaPos.z, 0.0f);
        //お互いの方向ベクトルの外積をして、法線ベクトルを出す。
        Vector3 v3Normal = Vector3.Cross(RefTarget.v3Direction, v3Direction);
        //平行状態かを判定するブール
        bool bParallel = false;


        /*計算1*/
        //法線ベクトルの大きさがある一定より小さいと、平行状態
        if (v3Normal.sqrMagnitude < 0.001f) bParallel = true;
        //平行か、そうでないかの計算
        if (!bParallel)//平行でない
        {
             //1.両方の直線に垂直、かつ両方の直線と交わる直線を求める。

            /*計算用の行列の作成*/
            //4*4の単位行列の作成
            Matrix4x4 matSolve = Matrix4x4.identity;
            //列単位で数値を入れている。
            //1列目に方向ベクトル
            matSolve.SetColumn(0, new Vector4(v3Direction.x, v3Direction.y, v3Direction.z, 0.0f));
            //2列目にターゲットの方向ベクトルを反転させたもの
            matSolve.SetColumn(1, new Vector4(-RefTarget.v3Direction.x,-RefTarget.v3Direction.y,-RefTarget.v3Direction.z, 0.0f));
            //3列目に互いの法線ベクトル(つまり外積)
            matSolve.SetColumn(2, new Vector4(v3Normal.x, v3Normal.y, v3Normal.z, 0.0f));
            //最後に逆行列にする
            matSolve = matSolve.inverse;  

            /*行列の計算*/
            //教科書参考(p128)
            //パラメータsを出す。
            s = Vector4.Dot(matSolve.GetRow(0), v4DeltaPos);
            //パラメータtを出す。
            t = Vector4.Dot(matSolve.GetRow(1), v4DeltaPos);
        }
        else//平行
        {
            s = Vector3.Dot(v3Direction, v3DeltaPos) / Vector3.SqrMagnitude(v3Direction);
            t = Vector3.Dot(RefTarget.v3Direction, -v3DeltaPos) / Vector3.SqrMagnitude(RefTarget.v3Direction);
        }

        /*排他条件処理*/
        if (s < -1.0f) s = -1.0f;                    // sの下限
        if (s >  1.0f) s =  1.0f;                    // sの上限
        if (t < -1.0f) t = -1.0f;                    // tの下限
        if (t >  1.0f) t =  1.0f;                    // tの上限

        /*数値の作成2*/
        //サイズ調整された自分の方向ベクトルと自分の座標の相対ベクトル(加算)を出す。
        Vector3 v3MinPos1 = v3Direction * s + transform.position;
        //サイズ調整されたターゲットの方向ベクトルと自分の座標の相対ベクトル(加算)を出す。
        Vector3 v3MinPos2 = RefTarget.v3Direction * t + RefTarget.transform.position;
        //上記の相対ベクトルのマグニチュード
        float fDistSqr = Vector3.SqrMagnitude(v3MinPos1 - v3MinPos2);
        //自分とターゲットの半径の合計
        float ar = RefTarget.fRadius + fRadius;

        /*計算2*/
        //相対ベクトルの半径の合計の比較(マグニチュードのまま計算するためにar^2)
        if (fDistSqr < ar * ar)//半径の合計より小さいとき
        {
            if (!bParallel)
            {
                rend.material.color = colorHit;
            }
            else
            {
                rend.material.color = colorPararrelHit;
            }
        }
        else//半径の合計より大きいとき
        {
            if (!bParallel)
            {
                rend.material.color = colorNoHit;
            }
            else
            {
                rend.material.color = colorPararrelNoHit;
            }
        }
    }
}
