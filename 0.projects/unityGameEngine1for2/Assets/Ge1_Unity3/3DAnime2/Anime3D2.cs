using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime3D2 : MonoBehaviour
{
    //publicを付けることで、エディタ上から値を入力できる
    public string parameter = "";
    Animator animator;
    bool flag=false;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        //フラグの初期化
        flag = false;
        //Keyの受付
        if (Input.GetKey("down"))
        {
            flag = true;
        }
        //アニメーションの変更
        animator.SetBool(parameter,flag);
    }
}
