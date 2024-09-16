using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove1_2a : MonoBehaviour {
    private Vector3 v3Velocity = new Vector3( 0.2f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(v3Velocity);
        if (transform.position.x > 5.0f)                // 右側の壁
        {
            transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
            v3Velocity.x = -v3Velocity.x;
        }
        if (transform.position.x < -5.0f)                // 左側の壁
        {
            transform.position = new Vector3(-5.0f, transform.position.y, transform.position.z);
            v3Velocity.x = -v3Velocity.x;
        }
    }
}
