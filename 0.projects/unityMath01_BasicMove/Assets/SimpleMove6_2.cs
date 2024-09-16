using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove6_2 : MonoBehaviour {
    private const float fRot_r = 5.0f;                              // 回転半径
    private const float fAngle_Vel = 2.0f * Mathf.PI / 50.0f;       // 回転半径
    private Vector3 v3Position = new Vector3(fRot_r, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3(0.0f, 0.0f, fRot_r * fAngle_Vel);

    // Use this for initialization
    void Start () {
        transform.position = v3Position;

    }

    // Update is called once per frame
    void FixedUpdate() {
        v3Position += v3Velocity;                                                               // 位置に速度を
        v3Velocity += -new Vector3(v3Position.x, 0.0f, v3Position.z) * fAngle_Vel * fAngle_Vel; // 速度に加速度を
        transform.position = v3Position;

    }
}
