using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    float fspeed=0.01f;//速度
    Vector3 vspeed;

    // Start is called before the first frame update
    void Start()
    {
        //速度をベクトルに変換
        //右方向に向かうベクトル
        vspeed = new Vector3(fspeed,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレーム、一定方向に進む。
        this.transform.position += vspeed;
    }
}
