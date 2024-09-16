using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class C3RunCookie : MonoBehaviour
{
    Vector3 _speed, _firstSpeed, _jumpSpeed, _leftMove, _rightMove;
    Rigidbody _rb;
    int _state;
    int _timer;
    bool _jumpNow,_jump;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        _rb = this.gameObject.GetComponent<Rigidbody>();

        //数値設定
        _firstSpeed = new Vector3(0, 0, 3.2f);
        _speed = _firstSpeed;
        _jumpSpeed = new Vector3(0, 16.0f, 3.2f);
        _leftMove = new Vector3(-2.0f, 0, 0);//左
        _rightMove = new Vector3(2.0f, 0, 0);//右

        //状態変数
        _state = 0;
        _timer = 0;

        //フラグ初期化
        _jumpNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveCheck
        _state = MoveControll.MoveCheck();

        //ジャンプ
        if (_state == 1 && _jumpNow == false)
        {
            _jumpNow = true;
            _speed = _jumpSpeed;
            Debug.Log("jump");
        }
        //左
        if (_state == 2)
        {
            _rb.position += _leftMove;
        }
        //右
        if (_state == 3)
        {
            _rb.position += _rightMove;
        }

    }

    void FixedUpdate()
    {
        //一定加速度で動く
        _rb.AddForce( _speed);

        //ジャンプフラグ初期化
        if (_jumpNow == true)
        {
            //タイマ更新
            _timer++;

            //スピート初期化
            if (_timer > 32)
            {
                _speed = _firstSpeed;
                Debug.Log("endUp");
            }

            //フラグ初期化
            if(_timer > 56)
            {
                _jumpNow = false;
                _timer = 0;
                Debug.Log("endJump");
            }
        }
    }
}

//スワイプ処理
public static class MoveControll
{
    static int ans = 0;
    static float first = 0;
    static float last = 0;
    static float del = 0;
    static int inputState = 0;

    /// <summary>
    /// 左・右・上のいずれかの移動判定.
    ///返り値(int).何もなし:0,jump:1,左2:,右:3
    /// </summary>
    /// <returns></returns>
    public static int MoveCheck()
    {
        //初期化
        if (inputState == 2)
        {
            ans = 0;
            first = 0;
            last = 0;
            del = 0;
            inputState = 0;
        }
        //クリック時に始点座標を代入
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            first = Input.mousePosition.x;
            inputState = 1;
        }
        //クリックを離した際に終点座標を代入
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            last = Input.mousePosition.x;
            inputState = 2;
            //移動距離を出す
            del = first - last;
            //移動方向を決める。
            if (del < -100)
            {
                ans = 3;//右
            }
            else if (del > 100)
            {

                ans = 2;//左
            }
            else
            {
                ans = 1;//Jump
            }
        }

        return ans;
    }
}
