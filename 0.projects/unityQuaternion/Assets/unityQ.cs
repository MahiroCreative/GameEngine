using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityQ : MonoBehaviour
{
    float _angle;
    Vector3 _axis;
    Quaternion q;

    private void Start()
    {
        //角速度[/s]
        _angle = 2 * Mathf.PI * 0.1f;//36度

        //回転軸の作成
        _axis = new Vector3(1,1,1);

        //_axis軸周りを各速度_angleで回転する回転クォータニオン
        //(角速度を渡しているので、1秒間で_angle回転)
        q = Quaternion.AngleAxis(_angle,_axis);
    }

    private void FixedUpdate()
    {
        /*座標変換*/
        //[回転後の座標] = [回転クオータニオン]*[現在の座標]
        //右辺で[クオータニオン]*[vector3]を行っているが、
        //結果はvector3になっている事に注目(オーバーロードでそのように定義)。
        transform.position = q * transform.position;
    }
}
