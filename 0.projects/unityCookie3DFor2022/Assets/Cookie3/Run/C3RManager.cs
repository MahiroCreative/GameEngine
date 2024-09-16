using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C3RManager : MonoBehaviour
{
    GameObject cookie;

    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("C3RunCookie");
    }

    // Update is called once per frame
    void Update()
    {
        //èâä˙à íuÇ…ñﬂÇÈ
        if (cookie.transform.position.y < - 2.4f)
        {
            cookie.transform.position = new Vector3(0, 1.2f, 0);
        }

        //ÉNÉäÉA
        if(cookie.transform.position.z > 104)
        {
            SceneManager.LoadScene("Cookie3/Cookie3");
        }

           
    }
}
