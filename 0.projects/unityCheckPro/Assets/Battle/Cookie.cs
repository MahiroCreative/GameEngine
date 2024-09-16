using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    Vector3 _move,_moveDamage,_firstPos;
    GameObject[] _hpList;
    GameObject _clearUI;
    GameObject _human;
    int timer;
    int hpCount;
    bool _damaging;

    // Start is called before the first frame update
    void Start()
    {
        _move = new Vector3(0, -0.04f, 0);
        _moveDamage = new Vector3(2.4f, 0 ,0);
        _firstPos = this.transform.position;
        _hpList = new GameObject[3];
        _hpList[0] = GameObject.Find("Canvas/Hp1");
        _hpList[1] = GameObject.Find("Canvas/Hp2");
        _hpList[2] = GameObject.Find("Canvas/Hp3");
        _clearUI = GameObject.Find("Canvas/ClearUI");
        _human = GameObject.Find("Human");
        hpCount = 0;
        timer = 0;
        _clearUI.SetActive(false);
        _damaging = false;
    }


    private void Update()
    {
        //攻撃を受けたら
        if(Human._attaking == true　&& _damaging == false)
        {
            if (Mathf.Abs(this.transform.position.x - _human.transform.position.x) < 20.0f)
            {
                Human._attaking = false;
                _hpList[hpCount].SetActive(false);
                Debug.Log("hit");
                hpCount++;
                _damaging=true;
                timer=0;

                if(hpCount>2)
                {
                    _clearUI.SetActive(true);
                }
            }
        }
    }

    //上下移動してるだけ
    void FixedUpdate()
    {

        if(_damaging)//ダメージを受けた際の動作
        {
            /**/
            this.transform.position += _moveDamage;

            //反転
            if (timer > 4)
            {
                this.transform.position = _firstPos;
                timer = 0;
                _damaging = false;
            }
        }
        else//通常動作
        {
            /*上下移動*/
            this.transform.position += _move;

            //反転
            if (timer > 75)
            {
                _move *= -1;
                timer = 0;
            }
        }


        //タイマ更新
        timer++;

    }
}
