using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBall : MonoBehaviour {
    public GameObject ball;
    private int nCount = 0;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if ( (nCount % 5) == 0 )
        {
           Instantiate(ball);
        }
        nCount++;
	}
}
