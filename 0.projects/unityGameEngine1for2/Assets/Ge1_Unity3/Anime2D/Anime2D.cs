using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime2D : MonoBehaviour
{
    //ïœêî
    GameObject one, two, three, four;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        one = GameObject.Find("1");
        two = GameObject.Find("2");
        three = GameObject.Find("3");
        four = GameObject.Find("4");
        one.SetActive(true);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count < 12)
        {
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
        }
        else if(count < 24)
        {
            one.SetActive(false);
            two.SetActive(true);
            three.SetActive(false);
            four.SetActive(false);
        }
        else if(count < 36)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
            four.SetActive(false);
        }
        else if(count < 48)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(true);
        }
        else
        {
            count = 0;
        }
        count++;
    }
}
