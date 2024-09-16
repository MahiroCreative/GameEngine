using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCubeScript : MonoBehaviour {
    public GameObject cube;
    private int nCount = 0;
    private const int nObjCount = 3;
    private const float fInterval = 4.0f;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        int i;
        GameObject GameObje;
        for (i = 0; i < nObjCount; i++) {
            GameObje = Instantiate(cube);
            GameObje.transform.position = new Vector3( ( ( float )( i - nObjCount / 2 ) ) * fInterval, 0.0f, 0.0f);
            GameObje = Instantiate(cube);
            GameObje.transform.position = new Vector3(0.0f, ((float)(i - nObjCount / 2)) * fInterval, 0.0f);
            GameObje = Instantiate(cube);
            GameObje.transform.position = new Vector3(0.0f, 0.0f, ((float)(i - nObjCount / 2)) * fInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
