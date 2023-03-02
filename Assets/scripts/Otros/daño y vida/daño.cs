using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    [SerializeField] int _daño;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Player.GetComponent<datosPlayer>().vidaPlayer-= _daño;
        }

        if (other.tag=="Enemigo")
        {
            Debug.Log("esto es un enemigo");
        }
    }
}
