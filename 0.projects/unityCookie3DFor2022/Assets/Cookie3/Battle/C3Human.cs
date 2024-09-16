using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3Human : MonoBehaviour
{
    public bool _trigger=false;

    void OnTriggerEnter(Collider other)
    {
        _trigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        _trigger = false; 
    }
}
