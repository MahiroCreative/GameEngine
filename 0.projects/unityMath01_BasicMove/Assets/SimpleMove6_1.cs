using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove6_1 : MonoBehaviour {
    private const float fRot_r = 5.0f;                              // 回転半径
    private Vector3 v3Position = new Vector3(fRot_r, 0.5f, 0.0f);   // 位置
    private float fAngle = 0.0f;                                    // 角度

    // Use this for initialization
    void Start () {
        transform.position = v3Position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        v3Position = new Vector3( fRot_r * Mathf.Cos(fAngle), 0.5f,
                                  fRot_r * Mathf.Sin(fAngle) );     // 回転
        fAngle += 2.0f * Mathf.PI / 50.0f;                          // 角度を進める
        transform.position = v3Position;

    }
}
