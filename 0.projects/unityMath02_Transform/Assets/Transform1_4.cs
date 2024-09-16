using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Transform1_4 : MonoBehaviour 
{
    private float bAngle = 0.0f;
    private float fAngleZ = 0.0f;
    private float fAngleX = 0.0f;
    private float fAngleY = 0.0f;
    Vector3 v3InitialPos;                       // 初期位置

    // Use this for initialization
    void Start()
    {
        v3InitialPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*unityの回転はZXY*/
        //bAngle = 2.0f * Mathf.PI * ((Time.time / 10.0f) % 1);//ベース角度
        bAngle = 2.0f * Mathf.PI;

        // Z回転の行列
        fAngleZ += bAngle * 0.01f;
        Matrix4x4 matZ = Matrix4x4.identity;                      // 単位行列
        matZ.m00 = Mathf.Cos(fAngleZ); matZ.m01 = -Mathf.Sin(fAngleZ);
        matZ.m10 = Mathf.Sin(fAngleZ); matZ.m11 = Mathf.Cos(fAngleZ);

        // X回転の行列
        fAngleX += bAngle * 0.01f;
        Matrix4x4 matX = Matrix4x4.identity;                      // 単位行列
        matX.m11 = Mathf.Cos(fAngleX); matX.m12 = -Mathf.Sin(fAngleX);
        matX.m21 = Mathf.Sin(fAngleX); matX.m22 = Mathf.Cos(fAngleX);

        // Y回転の行列
        fAngleY += bAngle * 0.01f;
        Matrix4x4 matY = Matrix4x4.identity;                      // 単位行列
        matY.m00 = Mathf.Cos(fAngleY); matY.m02 = Mathf.Sin(fAngleY);
        matY.m20 = -Mathf.Sin(fAngleY); matY.m22 = Mathf.Cos(fAngleY);

        /*合成*/
        Matrix4x4 matTransform;
        //YXZ回転
        //matTransform = matZ;
        //matTransform = matX * matZ;
        //matTransform = matY * matX * matZ;
        //ZXY回転
        matTransform = matY;
        matTransform = matX * matY;
        //matTransform = matZ * matX * matY;
        //XYZ回転
        //matTransform = matZ;
        //matTransform = matY * matZ;
        //matTransform = matX * matY * matZ;

        //変換
        transform.position = matTransform * v3InitialPos;
    }
}
