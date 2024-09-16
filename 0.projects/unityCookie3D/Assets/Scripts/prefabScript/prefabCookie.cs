using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabCookie : MonoBehaviour
{
    /*•Ï”*/
    Vector3 _speed;

    void Start()
    {
        _speed = new Vector3(0,0.2f,0);
    }

    void Update()
    {
        //—‰º
        transform.position -= _speed;

        //‚ ‚é’ö“x—‰º‚µ‚½‚çÁ‚·
        if(transform.position.y < -16.0f)
        {
            Destroy(gameObject);
        }

    }
}
