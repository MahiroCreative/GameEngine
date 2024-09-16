using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Vector3 _del = new Vector3(0,0.02f,0);

    // Update is called once per frame
    void Update()
    {
        //—‰ºˆ—
        this.transform.position -= _del; 
    }
}
