using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeControll : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("dragon").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up"))
        {
            anim.Play("up");
        }
        if (Input.GetKey("down"))
        {
            anim.Play("down");
        }
        if (Input.GetKey("left"))
        {
            anim.Play("left");
        }
        if (Input.GetKey("right"))
        {
            anim.Play("right");
        }
    }
}
