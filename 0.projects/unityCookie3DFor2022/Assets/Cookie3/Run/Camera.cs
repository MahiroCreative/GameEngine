using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject _cookie;
    Vector3 _delPos;

    // Start is called before the first frame update
    void Start()
    {
        _cookie = GameObject.Find("C3RunCookie");
        _delPos = new Vector3(0,2.8f,-6);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _cookie.transform.position + _delPos;
    }
}
