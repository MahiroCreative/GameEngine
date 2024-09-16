using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform2_1 : MonoBehaviour {
    Vector3 v3Position;
    Matrix4x4 matTransform;
    public Renderer rend;
    public Color colorCube = Color.red;
    GameObject target; 

    // Use this for initialization
    void Start()
    {
        float fXAbs, fYAbs, fZAbs;

        rend = GetComponent<Renderer>();
        target = GameObject.Find("Sphere");

        v3Position = transform.position;

        fXAbs = Mathf.Abs(transform.position.x);
        fYAbs = Mathf.Abs(transform.position.y);
        fZAbs = Mathf.Abs(transform.position.z);

        if ((fXAbs > fYAbs) && (fXAbs > fZAbs))
        {
            colorCube = Color.magenta;
        }
        else
        {
            if (fYAbs > fZAbs)
            {
                colorCube = Color.cyan;
            }
            else
            {
                colorCube = Color.yellow;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v3Side, v3Up, v3Forward;

        /*変換ベクトルの作成*/
        /*変換用のz軸の作成*/
        //弾がある場所が正面である。
        //正面とは、z軸なので。原点から弾がある方向に向かうベクトルがz軸でる。
        //なので、弾の場所までのベクトルを出して、それを単位ベクトルにしている。
        v3Forward = Vector3.Normalize(target.transform.position);

        /*変換用のx軸の作成*/
        //仮の上方向
        v3Up = new Vector3(0.0f, 0.0f, 1.0f);
        //上記とz軸の外積でz軸と垂直なベクトルを出す
        v3Side = Vector3.Cross(v3Up, v3Forward);
        //それをノーマライズして、x軸方向のベクトル作成
        v3Side = Vector3.Normalize(v3Side);

        /*変換用のy軸の作成*/
        v3Up = Vector3.Cross(v3Forward, v3Side);

        /*変換行列の作成*/
        // 単位行列
        matTransform = Matrix4x4.identity;
        // 回転の行列
        //z軸の基底ベクトルの挿入
        matTransform.m02 = v3Forward.x;
        matTransform.m12 = v3Forward.y;
        matTransform.m22 = v3Forward.z;
        //x軸の基底ベクトルの挿入
        matTransform.m00 = v3Side.x;
        matTransform.m10 = v3Side.y;
        matTransform.m20 = v3Side.z;
        //y軸の基底ベクトルの挿入
        matTransform.m01 = v3Up.x;
        matTransform.m11 = v3Up.y;
        matTransform.m21 = v3Up.z; 

        /*行列変換*/
        transform.position = matTransform * v3Position;

        //角度をターゲットに向けて、色を変えている
        //transform.LookAt(target.transform.position, new Vector3(0.0f, 0.0f, 1.0f));
        rend.material.color = colorCube;
    }
}
