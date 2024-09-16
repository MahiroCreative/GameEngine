using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove4_3 : MonoBehaviour {
    private Vector3 v3BasePosition = new Vector3(-5.0f, 0.5f, 0.0f);
    private Vector3 v3BaseVelocity = new Vector3(0.1f, 0.2f, 0.0f);
    private Vector3 v3Position;
    private float fGravity = -0.003f;
    private float t = 0.0f;                             // 時刻


    // Use this for initialization
    void Start()
    {
        v3Position = v3BasePosition;                    // 位置を初期化
        t = 0.0f;                                       // 時刻を初期化
        transform.position = v3Position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v3Position.x = v3BaseVelocity.x * t + v3BasePosition.x;                       // 位置に速度を足す
        v3Position.y = 0.5f * fGravity * t * t + v3BaseVelocity.y * t + v3BasePosition.y;                       // 速度に加速度を足す
        t++;

        if (v3Position.y < 0.0f)                       // 地面に落ちたか
        {
            t = 0.0f;                                   // 時刻を初期化
        }

        transform.position = v3Position;
    }
}
