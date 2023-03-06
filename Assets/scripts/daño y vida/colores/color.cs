using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class color : MonoBehaviour
{
    private bool CausaDaño = false;
    private Renderer colorCubo;
    [SerializeField] int _daño;
    public GameObject Player;

    private void Start()
    {
        colorCubo = GetComponent<Renderer>();
        colorCubo.material.SetColor("_Color", Color.red);
        CausaDaño = true;
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
        if (CausaDaño == true)
        {
            colorCubo.material.SetColor("_Color", Color.blue);
            CausaDaño = false;
            
        }
        else
        {
            colorCubo.material.SetColor("_Color", Color.red);
            CausaDaño = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CausaDaño)
        {
            Player.GetComponent<datosPlayer>().vidaPlayer -= _daño;
        }

        if (other.tag == "Enemigo")
        {
            Debug.Log("esto es un enemigo");
        }
    }
}
