using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    Vector3 arrow = new Vector3(-1.0f, 1.0f, 1.0f);
    Quaternion delQ;

    // Start is called before the first frame update
    void Start()
    {
        delQ = Quaternion.AngleAxis(1.0f,arrow);
    }
    private void FixedUpdate()
    {
        this.transform.rotation = delQ * this.transform.rotation;
    }
}
