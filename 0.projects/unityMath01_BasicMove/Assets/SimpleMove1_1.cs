using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove1_1 : MonoBehaviour {
    private Vector3 v3Position = new Vector3( 0.0f, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3( 0.2f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        transform.position = v3Position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        v3Position += v3Velocity;
        transform.position = v3Position;
    }
}
