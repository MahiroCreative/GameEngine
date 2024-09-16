using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //ƒNƒŠƒbƒNŽž
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Cookie2/Cookie2");
        }
    }
}
