using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove5_1a : MonoBehaviour {
    private Vector3 v3BasePosition = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;
    private float fGravity = -0.003f;


    // Use this for initialization
    void Start()
    {
        float fRadius, fAngle;
        v3Position = v3BasePosition;                            // 位置を初期化
        fRadius = Random.Range(0.0f, 0.2f);
        fAngle = Random.Range(0.0f, 2.0f * Mathf.PI);
        v3Velocity = new Vector3(fRadius * Mathf.Cos(fAngle), 0.2f,
                                 fRadius * Mathf.Sin(fAngle));    // 速度を初期化
        transform.position = v3Position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v3Position += v3Velocity;                       // 位置に速度を足す
        v3Velocity.y += fGravity;                       // 速度に加速度を足す

        if (v3Position.y < 0.0f)                       // 地面に落ちたか
        {
            Destroy(gameObject);
        }

        transform.position = v3Position;
    }
}
