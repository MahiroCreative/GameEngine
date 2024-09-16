using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    Vector3 yPos;//自分の位置(x,y)
    Vector3 speed;//自分の速度
    Vector3 firstSpeed;//初速度
    Vector3 accel;//加速度
    Vector3 firstPos;//最初の位置
    int time;//時間

    // Start is called before the first frame update
    void Start()
    {
        //最初の位置の取得
        firstPos = this.transform.position;
        //加速度
        accel = new Vector3(0,-0.00098f,0);
        //初速度
        firstSpeed = new Vector3(0, 0.1f, 0);
        //速度に初速度を入れる
        speed = firstSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ///*プログラミング的な書き方*/
        ////速度計算
        ////前回のフレームの速度に加速度を足すことで、今回のフレームの速度が出る。
        //speed += accel;

        ////位置の更新
        ////前回のフレームの位置に今回のフレームの速度を足すことで、今回のフレームの位置が出る。
        //this.transform.position += speed;

        /*物理の式*/
        //1/2gt^2 + v0t + 最初の位置
        this.transform.position = 0.5f*accel*time*time + firstSpeed*time + firstPos;

        //タイマの更新
        time++;
    }
}
