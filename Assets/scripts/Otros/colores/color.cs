using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class color : MonoBehaviour
{
    private bool esColor = false;
    private Renderer colorCubo;
    public GameObject Player;

    private void Start()
    {
        colorCubo = GetComponent<Renderer>();
        colorCubo.material.SetColor("_Color", Color.red);
        esColor = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambiamosColor();
        }
    }

    private void cambiamosColor()
    {
        if (esColor== true)
        {
            colorCubo.material.SetColor("_Color", Color.red);
            esColor = false;
            Player.GetComponent<daño>();
        }
        else
        {
            colorCubo.material.SetColor("_Color", Color.blue);
            esColor = true;

        }
    }
}
