using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove3_1 : MonoBehaviour {
    private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3(0.1f, 0.0f, 0.0f);
    private float fVelocity = 0.1f;
    private float fAngle = Mathf.PI / 6.0f;


    // Use this for initialization
    void Start()
    {
        transform.position = v3Position;
        v3Velocity.x = fVelocity * Mathf.Cos(fAngle);   // 初速の設定
        v3Velocity.z = fVelocity * Mathf.Sin(fAngle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v3Position += v3Velocity;                       // 位置に速度を足す

        if ((v3Position.x > 5.0f) || (v3Position.x < -5.0f) ||
            (v3Position.z > 5.0f) || (v3Position.z < -5.0f) )// 地面から出ているか
        {
            v3Position = new Vector3(0.0f, 0.5f, 0.0f);     // 位置を初期化
        }

        transform.position = v3Position;
    }
}
