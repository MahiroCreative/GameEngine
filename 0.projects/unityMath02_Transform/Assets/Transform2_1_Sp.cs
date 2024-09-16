using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform2_1_Sp : MonoBehaviour {
    private const float fFloorSize = 10.0f;
    private Vector3 v3Position = new Vector3(0.0f, -4.5f, 0.0f);
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
        v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

        v3Position += v3Velocity;                       // 位置に速度を足す

        if (v3Position.x > fFloorSize)                // 右側の壁
        {
            v3Position.x = fFloorSize;
        }
        if (v3Position.x < -fFloorSize)                // 左側の壁
        {
            v3Position.x = -fFloorSize;
        }
        if (v3Position.z > fFloorSize)                // 奥側の壁
        {
            v3Position.z = fFloorSize;
        }
        if (v3Position.z < -fFloorSize)                // 手前側の壁
        {
            v3Position.z = -fFloorSize;
        }

        transform.position = v3Position;
    }
}
