using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    GameObject _cube;
    Vector3 _position;


    // Start is called before the first frame update
    void Start()
    {
        //Resourcesから、Cubeプレハブを取得
        _cube = (GameObject)Resources.Load("Cube");
        //Cubeが生成されてほしい場所
        _position = new Vector3(0,6,0);
    }

    public void OnClick()
    {
        //Cubeの生成
        Instantiate(_cube,_position,Quaternion.identity);
    }

}
