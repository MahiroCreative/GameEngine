using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransformSample : MonoBehaviour
{
    //ˆÚ“®ŠÖ˜A
    float speed = 0.2f;
    Vector3 moveX, moveY;

    //Šg‘åAk¬—Ê
    float scaleSize = 0.5f;
    Vector3 delScale;

    //‰ñ“]
    Vector3 arrow = new Vector3(0,1,0);//²
    float angle = 0.5f;//‰ñ“]—Ê
    Quaternion qr,ql;


    private void Start()
    {
        //ˆÚ“®—Ê‚Ìì¬
        moveX = new Vector3(speed,0,0);
        moveY = new Vector3(0, speed, 0);

        //‰ñ“]—Ê‚Ìì¬
        delScale = new Vector3(scaleSize,scaleSize,scaleSize);

        //‰ñ“]ƒNƒH[ƒ^ƒjƒIƒ“‚Ìì¬
        qr = Quaternion.AngleAxis(-angle,arrow);
        ql = Quaternion.AngleAxis(angle, arrow);
    }

    private void Update()
    {
        //ˆÚ“®
        //¶
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= moveX;
        }
        //‰E
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += moveX;
        }
        //ã
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += moveY;
        }
        //‰º
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= moveY;
        }

        //Šg‘åk¬
        if(Input.GetKey(KeyCode.Q))//Šg‘å
        {
            this.transform.localScale += delScale;
        }
        if(Input.GetKey(KeyCode.Z))//k¬
        {
            this.transform.localScale -= delScale;
        }

        //‰ñ“]
        if(Input.GetMouseButton(1))//‰E
        {
            this.transform.rotation = qr * this.transform.rotation;
        }
        if (Input.GetMouseButton(0))//¶
        {
            this.transform.rotation = ql * this.transform.rotation;
        }

    }

}
