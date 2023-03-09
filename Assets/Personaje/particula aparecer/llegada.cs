using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llegada : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
