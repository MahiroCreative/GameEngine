using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2 : MonoBehaviour
{
    GameObject _cube1, _cube2;
    float del;
    Vector3 _move1, _move2, _temp;
    bool turnFlag;

    // Start is called before the first frame update
    void Start()
    {
        _cube1 = GameObject.Find("Cube1");
        _cube2 = GameObject.Find("Cube2");
        _move1 = new Vector3(-0.02f, 0, 0);
        _move2 = new Vector3(0.02f, 0, 0);
        _temp = new Vector3();
        turnFlag = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //À•W‚Æ‘Š‘Î‹——£‚ğo‚·
        del = _cube1.transform.position.x - _cube2.transform.position.x;
        del = Mathf.Abs(del);//ˆø”‚Ìâ‘Î’l‚ğ•Ô‚·
        //ˆÚ“®
        _cube1.transform.position += _move1;
        _cube2.transform.position += _move2;
        //”½“]
        if (del < 2.0f && turnFlag == true)
        {
            _temp = _move1;
            _move1 = _move2;
            _move2 = _temp;
            turnFlag = false;
        }
        else if(del > 8.0f && turnFlag ==false)
        {
            _temp = _move1;
            _move1 = _move2;
            _move2 = _temp;
            turnFlag = true;
        }
    }
}
