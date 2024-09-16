using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myQ : MonoBehaviour
{
    float _angle;
    Vector3 _axis;
    Quaternion q;

    // Start is called before the first frame update
    void Start()
    {
        //回転角度(角速度でないことに注意)
        _angle = 2 * Mathf.PI * 0.002f;//0.72度

        //回転軸の作成
        _axis = new Vector3(-1, 1, 1);

        //回転軸を単位ベクトルに直す(正規化する)
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

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*座標変換*/
        //(1frame毎に_angle回転)
        transform.position = q * transform.position;
    }
}
