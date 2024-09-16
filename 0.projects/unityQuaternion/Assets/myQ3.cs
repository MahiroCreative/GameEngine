using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class myQ3 : MonoBehaviour
{
    float _angle;
    Vector3 _axis;
    MyQuaternion q;

    // Start is called before the first frame update
    void Start()
    {
        //回転角度(角速度でないことに注意)
        _angle = -2 * Mathf.PI * 0.002f;//0.72度

        //回転軸の作成
        _axis = new Vector3(1, 1, 1);

        //回転軸を単位行列に直す(正規化する)
        _axis.Normalize();

        //回転クォータニオンの作成
        //(w:実部 , ijk:虚部 とする)
        //n: ijk軸上の単位ベクトル(軸となるベクトル)
        //q = w cos(θ/2) + n sin(θ/2)
        q.w = Mathf.Cos(_angle / 2.0f);//実部
        q.x = _axis.x * Mathf.Sin(_angle / 2.0f);
        q.y = _axis.y * Mathf.Sin(_angle / 2.0f);
        q.z = _axis.z * Mathf.Sin(_angle / 2.0f);
    }

    private void FixedUpdate()
    {
        /*座標変換*/
        transform.position = q * transform.position;
    }
}

/// <summary>
/// 【ユーザ定義】クオータニオン型
/// </summary>
public struct MyQuaternion
{
    public float w, x, y, z;

    /*コンストラクタ*/
    public MyQuaternion(float w, float x, float y, float z)
    {
        this.w = w;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /*演算子オーバーロード*/
    //MyQuaternion * MyQuaternion
    public static MyQuaternion operator *(MyQuaternion lQ, MyQuaternion rQ)
    {
        MyQuaternion tempQ;

        /*クオータニオンの掛け算*/
        //公式通りです。
        tempQ.w = lQ.w * rQ.w - lQ.x * rQ.x - lQ.y * rQ.y - lQ.z * rQ.z;//実部
        tempQ.x = lQ.w * rQ.x + lQ.x * rQ.w + lQ.y * rQ.z - lQ.z * rQ.y;//虚部x
        tempQ.y = lQ.w * rQ.y + lQ.y * rQ.w + lQ.z * rQ.x - lQ.x * rQ.z;//虚部y
        tempQ.z = lQ.w * rQ.z + lQ.z * rQ.w + lQ.x * rQ.y - lQ.y * rQ.x;//虚部z

        return tempQ;
    }
    //MyQuaternion * Vector3
    public static Vector3 operator *(MyQuaternion qRot, Vector3 right)
    {
        MyQuaternion qPos, qInv;
        Vector3 vPos;

        //3次元座標をクオータニオンに変換
        qPos.w = 1.0f;
        qPos.x = right.x;
        qPos.y = right.y;
        qPos.z = right.z;

        //回転クォータニオンのインバースの作成
        //逆クォータニオンを出すのは大変なので、
        //3次元だと同じ値になる共役クオータニオンで作成(虚部だけマイナス反転)
        qInv = new MyQuaternion(qRot.w, -qRot.x, -qRot.y, -qRot.z);

        //回転後のクオータニオンの作成
        qPos = qRot * qPos * qInv;

        //３次元座標に戻す
        vPos.x = qPos.x;
        vPos.y = qPos.y;
        vPos.z = qPos.z;

        return vPos;
    }
}