using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class C3Cookie : MonoBehaviour
{
    public bool _trigger = false;
    Rigidbody _rb;
    Vector3 _UpDown;
    int _timer;
    int _state;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _UpDown = new Vector3(0,0.01f,0);
        _timer = 0;
        _state = 0;
    }

    void FixedUpdate()
    {
        /*モーション*/
        //待機
        if (_state == 0)
        {
            Wait();
        }
    }


    /*コライダー*/
    void OnTriggerEnter(Collider other)
    {
        _trigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        _trigger = false;
    }

    /*動作*/
    //待機
    void  Wait()
    {
        /*動作処理*/
        if(_timer < 50)
        {
            _rb.position += _UpDown;
        }
        else
        {
            _rb.position -= _UpDown;
        }

        /*timer更新*/
        _timer++;

        /*timer初期化*/
        if (_timer >= 100)
        {
            _timer = 0;
        }
    }
}
