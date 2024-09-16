using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCookie : MonoBehaviour
{
    Transform _subTrans;
    Vector3 _delVec1,_delVec2;

    // Start is called before the first frame update
    void Start()
    {
        _subTrans = this.gameObject.transform;
        _delVec1 = new Vector3(0,0.1f,0);
        _delVec2 = new Vector3(0,0.2f,0);
    }

    private void FixedUpdate()
    {
        if(_subTrans.position.y < -24)
        {
            //‰½‚à‚µ‚È‚¢
        }
        else if(_subTrans.position.z < 25)
        {
            _subTrans.position -= _delVec1;
        }
        else if(_subTrans.position.y > -24)
        {
            _subTrans.position -= _delVec2;
        }
        
    }
}
