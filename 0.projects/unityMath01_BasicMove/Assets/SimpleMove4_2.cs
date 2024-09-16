using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove4_2 : MonoBehaviour {
    private Vector3 v3BasePosition = new Vector3(-5.0f, 0.5f, 0.0f);
    private Vector3 v3BaseVelocity = new Vector3( 0.1f, 0.2f, 0.0f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;
    private float fGravity = -0.003f;


    // Use this for initialization
    void Start()
    {
        v3Position = v3BasePosition;                    // 位置を初期化
        v3Velocity = v3BaseVelocity;                    // 速度を初期化
        transform.position = v3Position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v3Position += v3Velocity;                       // 位置に速度を足す
        v3Velocity.y += fGravity;                       // 速度に加速度を足す

        if (v3Position.y < 0.0f)                       // 地面に落ちたか
        {
            v3Position = v3BasePosition;                // 位置を初期化
            v3Velocity = v3BaseVelocity;                // 速度を初期化
        }

        transform.position = v3Position;
    }
}
