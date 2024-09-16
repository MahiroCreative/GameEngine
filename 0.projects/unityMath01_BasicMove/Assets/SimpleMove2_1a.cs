using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove2_1a : MonoBehaviour {
    private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    private float fVelocity = 0.1f;


    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
        v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

        v3Position += v3Velocity;                       // 位置に速度を足す

        transform.position = v3Position;

        if (transform.position.x > 5.0f)                // 右側の壁
        {
            transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -5.0f)                // 左側の壁
        {
            transform.position = new Vector3(-5.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 5.0f)                // 奥側の壁
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 5.0f);
        }
        if (transform.position.z < -5.0f)                // 手前側の壁
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.0f);
        }
    }
}
