using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform5_1 : MonoBehaviour {
    //回転度数を入れる変数
    private float fAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
        //変数
        float fXAbs, fYAbs, fZAbs;

        //現在地のそれぞれの軸位置の絶対値を出している
        fXAbs = Mathf.Abs(transform.position.x);//x成分の大きさ
        fYAbs = Mathf.Abs(transform.position.y);//y成分の大きさ
        fZAbs = Mathf.Abs(transform.position.z);//z成分の大きさ
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //変数
        Quaternion qRot;
        //回転軸の作成
        Vector3 v3Axis = new Vector3(1.0f, 1.0f, 1.0f);

        // 角度
        fAngle = 2.0f * Mathf.PI * Time.deltaTime / 10.0f;


        /*回転のクォータニオンの作成(Unityだより)*/
        qRot = Quaternion.AngleAxis(fAngle * Mathf.Rad2Deg, v3Axis);

        /*回転のクォータニオンの作成(自分で作る)*/
        //軸ベクトルを単位ベクトル化する.
        v3Axis.Normalize();
        //クオータニオンの値を入れていく
        //実部に値を入れる
        qRot.w = Mathf.Cos(fAngle / 2.0f);
        //虚部の値を作成
        //虚部は、それぞれの成分に軸ベクトル(正規化済み)をかけて作成
        qRot.x = Mathf.Sin(fAngle / 2.0f) * v3Axis.x;
        qRot.y = Mathf.Sin(fAngle / 2.0f) * v3Axis.y;
        qRot.z = Mathf.Sin(fAngle / 2.0f) * v3Axis.z;


        // クォータニオンによる回転
        // 位置
        transform.position = qRot * transform.position;
        // 回転
        transform.rotation = qRot * transform.rotation;            
    }
}
