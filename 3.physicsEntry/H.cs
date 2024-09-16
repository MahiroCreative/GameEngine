using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H : MonoBehaviour
{
    Vector3 firstPos;
    Vector3 firstSpeed;
    Vector3 gravity;
    Vector3 speed;
    Vector3 temp;
    int time;
    float speedL = 0.05f;
    float speedX;
    float speedY;
    float angle = Mathf.PI / 6;//πは180度

    // Start is called before the first frame update
    void Start()
    {
        //初速度の分解
        speedX = speedL * Mathf.Cos(angle);
        speedY = speedL * Mathf.Sin(angle);

        //初速度のベクトルの作成
        firstSpeed = new Vector3 (speedX, speedY, 0);

        //速度の設定
        speed = firstSpeed;

        //重力加速度
        gravity = new Vector3 (0, -0.000198f,0 );

        //ベクトルを使わないほう
        temp = new Vector3 (0, 0, 0);
        firstPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        ///*ベクトルを使った計算*/
        //速度の更新
        speed += gravity;

        //現在地の更新
        transform.position += speed;

        ///*ベクトルを使わない*/
        //temp.x = speedX * time;
        //temp.y = speedY * time + 0.5f * gravity.y * time*time;

        //現在地の更新
        //this.transform.position = new Vector3(firstPos.x + temp.x,firstPos.y+temp.y,0);

        //タイマの更新
        //time++;


    }
}
