using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    float fspeed = 0;//速度
    float faccel = 0.0001f;//加速度
    Vector3 vspeed;

    // Start is called before the first frame update
    void Start()
    {
        //速度と加速度の初期化
        //ベクトルに変換
        vspeed = new Vector3();
  
    }

    // Update is called once per frame
    void Update()
    {
        //現在のフレームの速度の計算
        //前のフレームでの速度に1フレーム毎に増加する増加量を足してる
        //つまり、faccel加速度だが、[/s]ではなく、[/f]での加速度。
        fspeed = faccel + fspeed;

        //ベクトル変換
        vspeed = new Vector3(fspeed,0,0);

        //現在のフレームの速度を足す
        this.transform.position += vspeed;
    }
}
