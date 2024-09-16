using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove1_2 : MonoBehaviour {
    private Vector3 v3Position = new Vector3( 0.0f, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3( 0.2f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        transform.position = v3Position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        v3Position += v3Velocity;               // 位置に速度を足す
        if (v3Position.x > 5.0f)                // 右側の壁
        {
            v3Position.x = 5.0f;
            v3Velocity.x = -v3Velocity.x;
        }
        if (v3Position.x < -5.0f)                // 左側の壁
        {
            v3Position.x = -5.0f;
            v3Velocity.x = -v3Velocity.x;
        }
        transform.position = v3Position;         // 位置の反映
    }
}
