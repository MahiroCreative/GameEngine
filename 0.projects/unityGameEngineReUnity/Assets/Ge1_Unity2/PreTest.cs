using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreTest : MonoBehaviour
{
    int _time = 0;
    Vector3 _pos, _delPos;
    bool _copyFlag = false;

    void Start()
    {
        _delPos = new Vector3(0.8f, 0, 0.8f);
        _pos = transform.position + _delPos;
        _copyFlag = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //一定時間ごとに自分自身を複製する
        if (_time > 50 && _copyFlag == true)
        {
            //自分自身のプレハブインスタンスを一度だけ作成
            //Quantaernion.identity:回転していないという意味
            Instantiate(this.gameObject, _pos, Quaternion.identity);
            _copyFlag = false;
        }

        _time++;
    }
}
