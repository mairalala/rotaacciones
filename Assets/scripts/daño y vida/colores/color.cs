using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class color : MonoBehaviour
{
    private bool CausaDa�o = false;
    private Renderer colorCubo;
    [SerializeField] int _da�o;
    public GameObject Player;

    private void Start()
    {
        colorCubo = GetComponent<Renderer>();
        colorCubo.material.SetColor("_Color", Color.red);
        CausaDa�o = true;
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
        if (CausaDa�o == true)
        {
            colorCubo.material.SetColor("_Color", Color.blue);
            CausaDa�o = false;
            
        }
        else
        {
            colorCubo.material.SetColor("_Color", Color.red);
            CausaDa�o = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CausaDa�o)
        {
            Player.GetComponent<datosPlayer>().vidaPlayer -= _da�o;
        }

        if (other.tag == "Enemigo")
        {
            Debug.Log("esto es un enemigo");
        }
    }
}
