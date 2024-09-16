using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    GameObject rotateCube2;

    //•¨‘Ì‚Ì‰ŠúˆÊ’u‚ð“ü‚ê‚é•Ï”
    Vector3 firstPos;
    Vector3 lastPos;

    //s—ñ•Ï”‚Ìì¬
    Matrix4x4 roMatrixZ,roMatrixX,tempMatrix;
    //Šp“x—p‚Ì•Ï”
    float Angle=0;
    float delAngle;

    void Start()
    {
        //ƒIƒuƒWƒFƒNƒg‚ÌŽæ“¾
        rotateCube2 = GameObject.Find("rotateCube2");

        //•¨‘Ì‚Ì‰ŠúˆÊ’u‚Ì‘ã“ü
        firstPos = transform.position;
        lastPos = rotateCube2.transform.position;

        //Šp“x‚Ì‘‰Á—Ê‚ÌÝ’è(Mathf.PI==ƒÎ)
        delAngle = Mathf.PI * 0.001f;//1.8“x

        //‰ñ“]s—ñ‚Ì‰Šú‰»(’PˆÊs—ñ‚Ì‘ã“ü)
        roMatrixZ = Matrix4x4.identity;//z
        roMatrixX = Matrix4x4.identity;//x
        
    }

    // Update is called once per frame
    void Update()
    {
        //‰ñ“]s—ñ‚ÌXV(zŽ²‰ñ“])
        roMatrixZ.m00 = Mathf.Cos(Angle);
        roMatrixZ.m01 = -Mathf.Sin(Angle);
        roMatrixZ.m10 = Mathf.Sin(Angle);
        roMatrixZ.m11 = Mathf.Cos(Angle);

        ////‰ñ“]s—ñ‚ÌXV(xŽ²‰ñ“])
        //roMatrixX.m11 = Mathf.Cos(Angle);
        //roMatrixX.m12 = -Mathf.Sin(Angle);
        //roMatrixX.m21 = Mathf.Sin(Angle);
        //roMatrixX.m22 = Mathf.Cos(Angle);

        //s—ñ‚Ì‡¬
        tempMatrix = roMatrixX * roMatrixZ;

        //‰ñ“]‚ÌŒvŽZ
        //Â‚Ì‰ñ“]
        transform.position =  tempMatrix * firstPos;
        //—Î‚Ì‰ñ“]
        rotateCube2.transform.position = tempMatrix * lastPos;

        //Šp“x‚Ì‘‰Á
        Angle += delAngle;

        //Šp“x‚Ì‰Šú‰»
        if(Angle > 2 * Mathf.PI)
        {
            Angle = 0;
        }
    }
}
