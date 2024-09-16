using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    Vector3 _move,_moveZero,_moveRight,_moveLeft;
    int timer=0;
    int time = 28;
    bool _moving = false;
    public static bool _attaking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        _move = new Vector3(0,0,0);
        _moveRight = new Vector3(1.0f,0,0);
        _moveLeft = new Vector3(-1.0f, 0, 0);
        _moveZero = new Vector3(0,0,0);
    }

    void FixedUpdate()
    {
        rb.velocity += _move;

        //動作フラグ
        if(_moving ==true)
        {
            //指定時間動く
            if(timer < time)
            {
                timer++;//タイマ更新
            }
            else
            {
                //速度初期化
                _move = _moveZero;
                rb.velocity = _moveZero;
                //フラグ初期化
                _moving = false;
                _attaking = false;
                //タイマ初期化
                timer = 0;
            }

        }

    }

    public void RightWalk()
    {
        anim.SetTrigger("walk");
        _move = _moveRight;
        _moving = true;
    }

    public void LeftWalk()
    {
        anim.SetTrigger("back");
        _move = _moveLeft;
        _moving = true;
    }
    public void Attack()
    {
        anim.SetTrigger("attack");
        _moving = true;
        _attaking = true;
    }
}
