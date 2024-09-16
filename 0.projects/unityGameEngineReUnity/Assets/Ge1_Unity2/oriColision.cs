using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oriColision : MonoBehaviour
{
    //特に使わない
}

public static class BoxCollision
{
    //firstArrow
    static public Vector3[] fArrow =
    {
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(-0.5f,0.5f,0.5f),
        new Vector3(-0.5f,0.5f,-0.5f),
        new Vector3(0.5f,0.5f,-0.5f),
        new Vector3(0.5f,-0.5f,0.5f),
        new Vector3(-0.5f,-0.5f,0.5f),
        new Vector3(-0.5f,-0.5f,-0.5f),
        new Vector3(0.5f,-0.5f,-0.5f),
    };

    //当たり判定
    public static bool CheckCubeCol(Transform a, Transform b)
    {
        bool flag = false;

        //諸々取得
        Vector3[] adots = MakeDot(a);
        Vector3[] bdots = MakeDot(b);
        //abベクトルの作成
        Vector3 abArrow = b.position - a.position;
        //baベクトルの作成
        Vector3 baArrow = a.position - b.position;

        //衝突物と最小距離のdotを取得
        Vector3 aMinDot = MinDot(adots, b);
        Vector3 bMinDot = MinDot(adots, b);

        //中心をOとする
        //OaMinDotベクトルとabベクトルのなす角(度)
        var angle1 = Vector3.Angle(abArrow, aMinDot - a.position);
        //ObMinDotベクトルとabベクトルのなす角(度)
        var angle2 = Vector3.Angle(baArrow, bMinDot - b.position);

        //上記で出したそれぞれの大きさ
        float aLen = (aMinDot - a.position).magnitude * Mathf.Cos(angle1 * Mathf.Deg2Rad);
        float bLen = (bMinDot - a.position).magnitude * Mathf.Cos(angle2 * Mathf.Deg2Rad);

        //当たり判定
        if (abArrow.magnitude < aLen + bLen)
        {
            Debug.Log(abArrow.magnitude);
            flag = true;
        }


        return flag;
    }

    //衝突物と最小距離のdotを取得
    public static Vector3 MinDot(Vector3[] a, Transform b)
    {
        Vector3 ans = new Vector3();
        float del = (a[0] - b.position).magnitude;
        ans = a[0];

        foreach (var t in a)
        {
            if ((t - b.position).magnitude < del)
            {
                ans = t;
            }
        }
        return ans;
    }



    //回転角に合わせてdotを作成
    public static Vector3[] MakeDot(Transform a)
    {
        Vector3[] arrows = new Vector3[8];
        Vector3[] dots = new Vector3[8];

        //回転角を反映
        arrows[0] = a.transform.rotation * fArrow[0];
        arrows[1] = a.transform.rotation * fArrow[1];
        arrows[2] = a.transform.rotation * fArrow[2];
        arrows[3] = a.transform.rotation * fArrow[3];
        arrows[4] = a.transform.rotation * fArrow[4];
        arrows[5] = a.transform.rotation * fArrow[5];
        arrows[6] = a.transform.rotation * fArrow[6];
        arrows[7] = a.transform.rotation * fArrow[7];

        //dotを作成
        dots[0] = a.transform.position + arrows[0];
        dots[1] = a.transform.position + arrows[1];
        dots[2] = a.transform.position + arrows[2];
        dots[3] = a.transform.position + arrows[3];
        dots[4] = a.transform.position + arrows[4];
        dots[5] = a.transform.position + arrows[5];
        dots[6] = a.transform.position + arrows[6];
        dots[7] = a.transform.position + arrows[7];

        return dots;
    }
}