using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    Vector3 _delVec = new Vector3(0.02f, 0, 0);

    private void FixedUpdate()
    {
        this.transform.position += _delVec;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit2");
        _delVec = -_delVec;
    }

}
