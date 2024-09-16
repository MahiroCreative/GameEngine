using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCookie : MonoBehaviour
{
    Vector3 _arrow1, _arrow2, _arrow3;
    Vector3 _delScale;
    Vector3 _firstSize;
    Quaternion _delQ, _delQIn, _delQout;
    bool _onClick, _inClick;
    Dictionary<int, Transform> _subTrans;
    Dictionary<int, Vector3> _firstPos;
    int ranValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンスの生成
        _arrow1 = new Vector3(0.0f, 0.0f, 1.0f);
        _arrow2 = new Vector3(1.0f, 1.0f, 0.0f);
        _arrow3 = new Vector3(-1.0f, -1.0f, 0.0f);
        _delScale = new Vector3(0.02f, 0.02f, 0.01f);
        _subTrans = new Dictionary<int, Transform>();
        _firstPos = new Dictionary<int, Vector3>();

        _firstSize = this.transform.localScale;

        _delQ = Quaternion.AngleAxis(0.4f, _arrow1);
        _delQIn = Quaternion.AngleAxis(40.0f, _arrow2);
        _delQout = Quaternion.AngleAxis(0.2f, _arrow3);

        _onClick = false;
        _inClick = false;

        //subクッキーの取得
        _subTrans.Add(1, GameObject.Find("SubCookie1").transform);
        _subTrans.Add(2, GameObject.Find("SubCookie2").transform);
        _subTrans.Add(3, GameObject.Find("SubCookie3").transform);
        _subTrans.Add(4, GameObject.Find("SubCookie4").transform);
        _subTrans.Add(5, GameObject.Find("SubCookie5").transform);
        _subTrans.Add(6, GameObject.Find("SubCookie6").transform);
        _subTrans.Add(7, GameObject.Find("SubCookie7").transform);
        _subTrans.Add(8, GameObject.Find("SubCookie8").transform);
        _subTrans.Add(9, GameObject.Find("SubCookie9").transform);
        _subTrans.Add(10, GameObject.Find("SubCookie10").transform);
        _subTrans.Add(11, GameObject.Find("SubCookie11").transform);
        _subTrans.Add(12, GameObject.Find("SubCookie12").transform);
        _subTrans.Add(13, GameObject.Find("SubCookie13").transform);
        _subTrans.Add(14, GameObject.Find("SubCookie14").transform);
        _subTrans.Add(15, GameObject.Find("SubCookie15").transform);
        _subTrans.Add(16, GameObject.Find("SubCookie16").transform);

        //クッキーのy座標の初期位置の取得
        _firstPos.Add(1, new Vector3(_subTrans[1].position.x, 16, _subTrans[1].position.z));
        _firstPos.Add(2, new Vector3(_subTrans[2].position.x, 16, _subTrans[2].position.z));
        _firstPos.Add(3, new Vector3(_subTrans[3].position.x, 16, _subTrans[3].position.z));
        _firstPos.Add(4, new Vector3(_subTrans[4].position.x, 16, _subTrans[4].position.z));
        _firstPos.Add(5, new Vector3(_subTrans[5].position.x, 16, _subTrans[5].position.z));
        _firstPos.Add(6, new Vector3(_subTrans[6].position.x, 16, _subTrans[6].position.z));
        _firstPos.Add(7, new Vector3(_subTrans[7].position.x, 16, _subTrans[7].position.z));
        _firstPos.Add(8, new Vector3(_subTrans[8].position.x, 16, _subTrans[8].position.z));
        _firstPos.Add(9, new Vector3(_subTrans[9].position.x, 24, _subTrans[9].position.z));
        _firstPos.Add(10, new Vector3(_subTrans[10].position.x, 24, _subTrans[10].position.z));
        _firstPos.Add(11, new Vector3(_subTrans[11].position.x, 24, _subTrans[11].position.z));
        _firstPos.Add(12, new Vector3(_subTrans[12].position.x, 24, _subTrans[12].position.z));
        _firstPos.Add(13, new Vector3(_subTrans[13].position.x, 24, _subTrans[13].position.z));
        _firstPos.Add(14, new Vector3(_subTrans[14].position.x, 24, _subTrans[14].position.z));
        _firstPos.Add(15, new Vector3(_subTrans[15].position.x, 24, _subTrans[15].position.z));
        _firstPos.Add(16, new Vector3(_subTrans[16].position.x, 24, _subTrans[16].position.z));
    }
    private void FixedUpdate()
    {
        //常時回転
        this.transform.rotation = _delQ * this.transform.rotation;

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
        if (Input.GetMouseButtonDown(0) && _inClick == false)
        {
            Debug.Log("onClick");
            _onClick = true;
            _inClick = true;
        }

        if (this.transform.localScale.x < 0.8f)
        {
            Debug.Log("inClick");
            _inClick = false;
        }

        if ((this.transform.localScale.x > _firstSize.x) && _onClick == true)
        {
            Debug.Log("outClick");
            this.transform.localScale = _firstSize;
            _onClick = false;
            _inClick = false;

            //Subクッキーをランダムで上に戻す
            ranValue = Random.Range(1, 17);//1~8の乱数

            //画面に写っていたら戻さないようにする。
            if (_subTrans[ranValue].position.y < -16)
            {
                _subTrans[ranValue].position = _firstPos[ranValue];
            }


        }


    }
}
