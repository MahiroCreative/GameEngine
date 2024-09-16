using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform cameraT,cookieT;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        cookieT = GameObject.Find("Cookie").transform;
        cameraT = this.transform;
        newPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        newPos.Set(cameraT.position.x, cameraT.position.y, cookieT.position.z - 8.0f);
        cameraT.position = newPos;
    }
}
