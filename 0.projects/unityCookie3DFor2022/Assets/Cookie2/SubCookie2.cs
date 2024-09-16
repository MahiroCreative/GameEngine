using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCookie2 : MonoBehaviour
{
    //•Ï”
    Transform _pos;

    // Start is called before the first frame update
    void Start()
    {
        _pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //w’èˆÊ’u‚Ü‚Ås‚Á‚½‚çÁ‚¦‚é
        if(_pos.position.y <-24.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
