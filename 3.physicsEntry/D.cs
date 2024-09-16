using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D : MonoBehaviour
{
    float time = 0;//[/f]
    float firstSpeed = -0.02f; //[/f]
    float accel = 0.0001f;//[/f]
    float firstX;
    float x;

    // Start is called before the first frame update
    void Start()
    {
        firstX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //時間更新
        time++;

        //水平方向の運動の式
        //this.transform.position = 1 / 2 * vaccel * time * time + vspeed * time;
        x = 0.5f * accel * time * time + firstSpeed * time + firstX;

        //ベクトル変換かけて、現在の座標に代入
        this.transform.position = new Vector3(x, 0, 0);
    }
}
