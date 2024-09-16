using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //Quaternion
    Vector3 arrow = new Vector3(1.0f, 1.0f, 1.0f);//軸ベクトル
    Quaternion q;

    void Start()
    {
        //回転量をクオータニオンで作る。
        q = Quaternion.AngleAxis(1.0f,arrow);
    }

    // Update is called once per frame
    void Update()
    {
        //元の回転値と合成して上書き
        this.transform.rotation = q * this.transform.rotation;
    }
}