using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCookie3 : MonoBehaviour
{
    Vector3 _arrow1, _arrow2, _arrow3;
    Vector3 _delScale;
    Vector3 _firstSize;
    Quaternion _delQ, _delQIn, _delQout;
    bool _onClick, _inClick;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンスの生成
        _arrow1 = new Vector3(0.0f, 0.0f, 1.0f);//回転の真ん中
        _delScale = new Vector3(0.02f, 0.02f, 0.01f);//サイズが大きくなる単位時間

        //最初のサイズ
        _firstSize = this.transform.localScale;

        //回転度合い
        _delQ = Quaternion.AngleAxis(0.4f, _arrow1);

        //フラグ初期化
        _onClick = false;
        _inClick = false;
    }
    private void FixedUpdate()
    {
        //常時回転
        this.GetComponent<Rigidbody>().rotation = _delQ * this.transform.rotation;

        //クリック時に縮小
        if (_inClick)
        {
            this.transform.localScale -= _delScale;
        }

        //サイズが戻る
        if (_inClick == false && _onClick == true)
        {
            this.transform.localScale += _delScale * 1.5f;
        }

    }
    private void Update()
    {
        //クリック時
        if (Input.GetMouseButtonDown(0) && _inClick == false)
        {
            Debug.Log("onClick");
            _onClick = true;
            _inClick = true;
        }

        //元のサイズに戻っている最中
        if (this.transform.localScale.x < 0.8f)
        {
            Debug.Log("inClick");
            _inClick = false;
        }

        //元のサイズに戻った時
        if ((this.transform.localScale.x > _firstSize.x) && _onClick == true)
        {
            Debug.Log("outClick");
            this.transform.localScale = _firstSize;
            _onClick = false;
            _inClick = false;
        }
    }
}
