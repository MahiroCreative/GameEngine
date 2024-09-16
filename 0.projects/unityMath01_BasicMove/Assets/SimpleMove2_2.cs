using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove2_2 : MonoBehaviour {
    private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    private float fVelocity = 0.1f;


    // Use this for initialization
    void Start()
    {
        transform.position = v3Position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
        v3Velocity.z = Input.GetAxis("Vertical"  ) * fVelocity;

        v3Position += v3Velocity;                       // 位置に速度を足す

        if (v3Position.x > 5.0f)                // 右側の壁
        {
            v3Position.x = 5.0f;
        }
        if (v3Position.x < -5.0f)                // 左側の壁
        {
            v3Position.x = -5.0f;
        }
        if (v3Position.z > 5.0f)                // 奥側の壁
        {
            v3Position.z = 5.0f;
        }
        if (v3Position.z < -5.0f)                // 手前側の壁
        {
            v3Position.z = -5.0f;
        }

        transform.position = v3Position;
    }
}
