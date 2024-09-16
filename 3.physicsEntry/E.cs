using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour
{
    Vector2 yPos;//自分の位置(x,y)
    Vector2 speed;//自分の速度
    Vector2 accel;//加速度
    Vector2 temp;//計算結果の一時格納
    Vector2 firstPos;
    int time;//時間

    // Start is called before the first frame update
    void Start()
    {
        firstPos = this.transform.position;//オブジェクト作成時の位置
        speed = new Vector2();//ゼロ入れた
        accel = new Vector2(0,-0.00098f);
    }

    // Update is called once per frame
    void Update()
    {
        /*物理の式的な書き方*/
        ////いきなり現在地を出すの式に直す
        //this.transform.position = firstPos + 0.5f*accel*time*time;

        ////時間の更新
        //time++;

        /*プログラミングっぽい書き方*/
        //速度を毎フレーム計算する
        speed += accel;//単位時間ごとに加速するので加算

        //更新
        temp = this.transform.position;//現在地の代入
        temp += speed;//現在地の更新
        this.transform.position = temp;//オブジェクトに計算結果を反映
    }
}
