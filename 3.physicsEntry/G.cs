using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class G : MonoBehaviour
{
    Vector3 firstPos;
    Vector3 speed;
    float speedL=0.25f;
    float speedX;
    float speedY;
    float angle=Mathf.PI/6;//πは180度

    // Start is called before the first frame update
    void Start()
    {
       // speed = new Vector3(0.1f,0.1f,0);

        //速度の分解
        speedX = speedL * Mathf.Cos(angle);
        speedY = speedL * Mathf.Sin(angle);

        //ベクトルの速度の作成
        speed = new Vector3 (speedX, speedY, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += speed;
    }
}
