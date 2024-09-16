using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C3BattleManager : MonoBehaviour
{
    GameObject _human, _cookie;
    GameObject[] _hp,_mhp;
    GameObject _clear,_over,_push;
    Animator _anim;
    Vector3 _foward,_back;
    int _state;
    int _hpC;
    int _mhpC;
    float _del;
    bool _tFlag,_endFlag;
    int _timer;
    int _endTimer;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンスの作成
        _hp = new GameObject[4];
        _mhp = new GameObject[4];
        //代入
        _human = GameObject.Find("Human");
        _cookie = GameObject.Find("Cookie");
        _anim = _human.GetComponent<Animator>();
        _hp[0] = GameObject.Find("hp0");
        _hp[1] = GameObject.Find("hp1");
        _hp[2] = GameObject.Find("hp2");
        _hp[3] = GameObject.Find("hp3");
        _mhp[0] = GameObject.Find("mhp0");
        _mhp[1] = GameObject.Find("mhp1");
        _mhp[2] = GameObject.Find("mhp2");
        _mhp[3] = GameObject.Find("mhp3");
        _clear = GameObject.Find("clear");
        _clear.SetActive(false);
        _over = GameObject.Find("over");
        _over.SetActive(false);
        _push = GameObject.Find("push");
        _push.SetActive(false);
        _foward = new Vector3(0.01f,0,0);
        _back = new Vector3(-0.05f,0,0);
        _state = 0;
        _hpC = 0;
        _mhpC = 0;
        _del = 0;
        _timer = 0;
        _endTimer = 0;
        _tFlag = false;
        _endFlag = false;
    }

    void Update()
    {
        //トリガー管理
        if (_human.GetComponent<C3Human>()._trigger == true && _state !=2)
        {
            if(_state != 4)
            {
                _state = 1;
                _tFlag = true;
            }

        }

        //クリアorオーバー管理
        if(_hpC > 3)
        {
            _clear.SetActive(true);
            _push.SetActive(false);
        }
        else if(_mhpC >3)
        {
            _over.SetActive(true);
            _endFlag = true;
        }

        //クリア遷移管理
        if(_endTimer > 100)
        {
            SceneManager.LoadScene("Cookie3/Cookie3");
        }

    }

    private void FixedUpdate()
    {
        if(_state==0)
        {
            _human.transform.position += _foward;
            _cookie.transform.position -= _foward;
        }
        else if(_state==1)
        {
            //攻撃可能待機
        }
        else if (_state==2)
        {
            //相対距離
            _del = _human.transform.position.x - _cookie.transform.position.x;
            _del = Mathf.Abs(_del);

            if (_del < 14.0f)
            {
                //攻撃後移動
                _human.transform.position += _back;
                _cookie.transform.position -= _back;
            }
            else
            {
                _state = 0;
            }

        }

        //タイマー
        if(_tFlag == true)
        {
            _timer++;
        }
        if(_endFlag==true)
        {
            _endTimer++;
        }

        //クッキーの攻撃
        if(_timer >35 && _state !=4)
        {
            Debug.Log(_state);
            cAttack();
        }

        //Push
        if(_timer > 5 && _timer <30 && _state != 4)
        {
            _state=3;
        }


    }

    public void Attack()
    {
        if(_state ==1)
        {
            _anim.SetTrigger("attack");
            if(_hpC <4)
            {
                _hp[_hpC].SetActive(false);
                _hpC++;
            }
            _state = 2;
            _tFlag = false;
            _timer = 0;
        }
        else if(_state==4)
        {
            _anim.SetTrigger("attack");
            if (_hpC < 4)
            {
                _hp[_hpC].SetActive(false);
                _hpC++;
            }
        }
    }

    public void cAttack()
    {
        if (_mhpC < 4)
        {
            _mhp[_mhpC].SetActive(false);
            _mhpC++;
        }
        _state = 2;
        _tFlag = false;
        _timer = 0;
    }

    public void Push()
    {
        if(_state==3)
        {
            _push.SetActive(true);
            _state=4;
        }
    }
}
