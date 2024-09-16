using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myQ2 : MonoBehaviour
{
    float _angle;
    Vector3 _axis, _vPos;
    Quaternion qPos, qRot;

    // Start is called before the first frame update
    void Start()
    {
        //回転角度(角速度でないことに注意)
        _angle = 2 * Mathf.PI * 0.002f;//0.72度

        //回転軸の作成
        _axis = new Vector3(1, 1, 1);

        //回転軸を単位行列に直す(正規化する)
        _axis.Normalize();

        //回転クォータニオンの作成
        //(w:実部 , ijk:虚部 とする)
        //n: ijk軸上の単位ベクトル(軸となるベクトル)
        //q = w cos(θ/2) + n sin(θ/2)
        qRot.w = Mathf.Cos(_angle / 2.0f);//実部
        qRot.x = _axis.x * Mathf.Sin(_angle / 2.0f);
        qRot.y = _axis.y * Mathf.Sin(_angle / 2.0f);
        qRot.z = _axis.z * Mathf.Sin(_angle / 2.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*座標変換*/
        //transform.position = q * transform.position;
        //上記の計算をオーバーロードに頼らずに計算する。

        //現在の座標を取得
        _vPos = transform.position;
        
        //３次元座標をクオータニオンに変換
        qPos.w = 1.0f;//実部を1にすれば回転しない。
        qPos.x = _vPos.x;
        qPos.y = _vPos.y;
        qPos.z = _vPos.z;

        //回転後のクオータニオンの作成
        //[回転後のクオータニオン] =
        //[回転クオータニオン] * [現在のクオータニオン] * [回転クオータニオンのインバース]
        qPos = qRot * qPos * Quaternion.Inverse(qRot);

        //３次元座標に戻す
        _vPos.x = qPos.x;
        _vPos.y = qPos.y;
        _vPos.z = qPos.z;

        //座標変換
        transform.position = _vPos;
    }
}
