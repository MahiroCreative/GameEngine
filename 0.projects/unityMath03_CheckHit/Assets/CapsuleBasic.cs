using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBasic : MonoBehaviour {
    public Vector3 v3Direction;                 // 方向ベクトル
    public float fRadius;                       // 当たり半径
    private Quaternion qRot;

    // Use this for initialization
    void Start () {
        qRot = Quaternion.AngleAxis(45.0f, new Vector3(1.0f, 1.0f, -1.0f));
        v3Direction = new Vector3(0.0f, 0.5f, 0.0f);
        v3Direction = qRot * v3Direction;
        transform.rotation = qRot;
        fRadius = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
