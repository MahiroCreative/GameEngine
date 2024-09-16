using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igaguriGenerator : MonoBehaviour
{
    public GameObject igaguriprefab;
    GameObject igaguri;
    Vector3 dir;
    Ray ray;

    private void Start()
    {
        dir = new Vector3(0,200,2000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //いがぐりの生成
            igaguri = Instantiate(igaguriprefab);

            //射出位置の取得
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            dir = ray.direction;//光線の方向
            dir = dir.normalized * 2000;//正規化して、速度を掛けてる。

            igaguri.GetComponent<igaguriController>().Shoot(dir);
        }
    }
}
