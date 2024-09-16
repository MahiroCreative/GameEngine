using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunCookie : MonoBehaviour
{
    //変数
    Rigidbody rb;
    Vector3 _move, _moveRight, _moveLeft, _jump, _moveFirst;
    int conFlag = 0;
    bool jumpFlag = false;
    bool moveFlag = true;
    float maxJump = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _move = new Vector3(0, 0, 3.0f);
        _jump = new Vector3(0, 20.0f, 0);
        _moveFirst = new Vector3(0, 0, 3.0f);
        _moveRight = new Vector3(1.2f, 0, 0);
        _moveLeft = new Vector3(-1.2f, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //移動
        rb.AddForce(_move);

        if (jumpFlag == true)
        {
            //ジャンプできる最大位置
            if (rb.position.y > 2.8f + maxJump)
            {
                _move = _moveFirst;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.position.y > maxJump + 2.8f)
        {
            Debug.Log("jupPlus");
            maxJump = maxJump + 1.8f;
        }

        if (jumpFlag == true)
        {
            Debug.Log("hit");
            moveFlag = true;
            jumpFlag = false;

        }
    }

    private void Update()
    {
        //操作受付
        if (moveFlag)
        {
            conFlag = Controll.MoveControll();
        }

        //移動
        if (jumpFlag == false && (this.transform.position.y < 2.8f + maxJump))
        {
            if (conFlag == 3)//右
            {
                Debug.Log("right");
                rb.position += _moveRight;
            }
            else if (conFlag == 2)//左
            {
                Debug.Log("left");
                rb.position += _moveLeft;
            }
            else if (conFlag == 1)//jump
            {
                Debug.Log("jump");
                _move += _jump;
                jumpFlag = true;
                moveFlag = false;
            }
        }
        //異常なジャンプを制御
        if(rb.position.y > 8.0f)
        {
            _move = _moveFirst;
        }

        //クリア処理
        if (this.transform.position.z > 260.0f)
        {
            SceneManager.LoadScene("Cookie2");
        }

        //ゲームオーバー処理
        if (this.transform.position.y < -2.0f)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}

public static class Controll
{
    static int ans = 0;
    static float first = 0;
    static float last = 0;
    static float del = 0;
    static int inputState = 0;

    /// <summary>
    /// 左・右・上のいずれかの移動判定.
    ///返り値(int).何もなし:0,上:1,左2:,右:3
    /// </summary>
    /// <returns></returns>
    public static int MoveControll()
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
                ans = 1;
            }
        }

        return ans;
    }
}
