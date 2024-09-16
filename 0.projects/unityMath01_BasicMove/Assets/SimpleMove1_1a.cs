using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove1_1a : MonoBehaviour {
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0.2f, 0.0f, 0.0f);
    }
}
