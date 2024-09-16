using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push_Manager : MonoBehaviour
{
    /*カウント変数*/
    float _count = 0;
    float _deltaGen = 0;
    float _hand = 0;
    float _grandma = 0;
    float _factory = 0;

    /*タイマー*/
    float _timer = 0;

    /*位置*/
    float _handPos=-8;
    float _grandmaPos = -8;
    float _factoryPos = -8;

    /*オブジェクトとコンポーネント変数*/
    GameObject _obj;
    GameObject _grandmaObj;
    GameObject _handObj;
    GameObject _factoryObj;
    Transform _cookieTrans;
    Text _countText;
    Text _deltaText;

    /*クッキーの回転*/
    Vector3 _axis;//回転軸
    Quaternion _delQ;//回転度合い

    /*拡大縮小*/
    bool _bigFlag=false;
    Vector3 _minScale;
    Vector3 _delScale;

    void Start()
    {
        /*コンポーネント取得*/
        _cookieTrans = GameObject.Find("MainCookie").GetComponent<Transform>();
        _countText = GameObject.Find("countText").GetComponent<Text>();
        _deltaText = GameObject.Find("deltaCountText").GetComponent<Text>();

        /*prefabCookieの取得*/
        _obj = (GameObject)Resources.Load("prefabCookie");
        _handObj = (GameObject)Resources.Load("preHand");
        _grandmaObj = (GameObject)Resources.Load("preGrandma");
        _factoryObj = (GameObject)Resources.Load("preFactory");

        /*クッキーの回転*/
        //回転軸の作成
        _axis = new Vector3(0,0,1.0f);
        //回転クオータニオンの作成
        _delQ = Quaternion.AngleAxis(0.4f, _axis);

        /*拡大縮小*/
        _minScale = new Vector3(1.6f,1.6f,1.6f);
        _delScale = new Vector3(0.02f,0.02f,0.02f);
    }

    void FixedUpdate()
    {
        //常時回転
        _cookieTrans.rotation = _delQ * _cookieTrans.rotation;

        //クリック後に拡大
        if(_bigFlag && _cookieTrans.localScale.x <= 2.0f)
        {
            _cookieTrans.localScale += _delScale;
        }

        //カウントの更新
        _deltaGen = _hand + _grandma + _factory;
        _count += _deltaGen;

        //カウントの更新表示
        _countText.text = ((int)_count).ToString();

        //deltaの更新表示
        _deltaText.text = ((int)(_deltaGen *　51)).ToString();

        //deltaがある一定以上になったらクッキーを適当に降らす
        FallingCookie(_deltaGen);
    }



    /*動作メソッド*/
    /// <summary>
    /// _deltaGen(秒間のクッキーの生成量)の値に合わせて、
    /// 自動で落下してくるクッキーの量を増減させる。
    /// </summary>
    /// <param name="deltaGen"></param>
    public void FallingCookie(float deltaGen)
    {
        if (deltaGen > 3.2f)
        {
            //timer
            _timer += Time.deltaTime;

            if (_timer > 0.04f)
            {
                //乱数生成
                float x = Random.Range(-20.0f, 20.0f);
                float z = Random.Range(12.0f, 24.0f);
                //インスタンス生成
                Instantiate(_obj, new Vector3(x, 16.0f, z), Quaternion.Euler(0, 180, 0));

                //timerの初期化
                _timer = 0;
            }
        }
        else if (deltaGen > 0.80f)
        {
            //timer
            _timer += Time.deltaTime;

            if (_timer > 0.2f)
            {
                //乱数生成
                float x = Random.Range(-20.0f, 20.0f);
                float z = Random.Range(12.0f, 24.0f);
                //インスタンス生成
                Instantiate(_obj, new Vector3(x, 16.0f, z), Quaternion.Euler(0, 180, 0));

                //timerの初期化
                _timer = 0;
            }

        }
        else if (deltaGen > 0.08f)
        {
            //timer
            _timer += Time.deltaTime;

            if (_timer > 1.6f)
            {
                //乱数生成
                float x = Random.Range(-20.0f, 20.0f);
                float z = Random.Range(12.0f, 24.0f);
                //インスタンス生成
                Instantiate(_obj, new Vector3(x, 16.0f, z), Quaternion.Euler(0, 180, 0));

                //timerの初期化
                _timer = 0;
            }
        }
        else if (deltaGen > 0.01f)
        {
            //timer
            _timer += Time.deltaTime;

            if (_timer > 8.0f)
            {
                //乱数生成
                float x = Random.Range(-20.0f, 20.0f);
                float z = Random.Range(12.0f, 24.0f);
                //インスタンス生成
                Instantiate(_obj, new Vector3(x, 16.0f, z), Quaternion.Euler(0, 180, 0));

                //timerの初期化
                _timer = 0;
            }
        }
    }

    /*ボタンメソッド*/
    public void onClick()
    {
        //縮小
        _cookieTrans.localScale = _minScale; 
        //拡大フラグon
        _bigFlag = true;
        //カウントの更新
        _count += 1.0f;

        //乱数生成
        float x = Random.Range(-20.0f,20.0f);
        float z = Random.Range(12.0f,24.0f);
        //インスタンス生成(クッキー生成)
        Instantiate(_obj,new Vector3(x,16.0f,z),Quaternion.Euler(0,180,0));
    }

    public void handButton()
    {
        if(_count >= 8)
        {
            _count = _count - 8;
            _hand = _hand + 0.02f;
            //インスタンス生成(hand生成)
            Instantiate(_handObj, new Vector3(_handPos, 1.6f, 1), Quaternion.identity);
            //生成位置をずらす
            _handPos += 0.8f;
        }

    }
    public void granmaButton()
    {
        if(_count >= 80)
        {
            _count = _count - 80;
            _grandma = _grandma + 0.1f;
            //インスタンス生成(grandma生成)
            Instantiate(_grandmaObj, new Vector3(_grandmaPos, 0, 1), Quaternion.identity);
            //生成位置をずらす
            _grandmaPos += 0.8f;
        }

    }
    public void factoryButton()
    {
        if(_count > 800)
        {
            _count = _count - 800;
            _factory = _factory + 1.0f;
            //インスタンス生成(factory生成)
            Instantiate(_factoryObj, new Vector3(_factoryPos, -1.6f, 1), Quaternion.identity);
            //生成位置をずらす
            _factoryPos += 0.8f;
        }

    }
}
