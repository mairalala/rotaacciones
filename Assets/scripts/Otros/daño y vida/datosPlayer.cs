using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datosPlayer : MonoBehaviour
{
    public int vidaPlayer;
    public Slider vidaVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaVisual.GetComponent<Slider>().value = vidaPlayer;
        if (vidaPlayer<0)
        {
            Debug.Log("has perdido");
        }
    }
}
