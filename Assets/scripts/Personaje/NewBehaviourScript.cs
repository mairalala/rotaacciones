using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
        public ParticleSystem[] particulas; // Arreglo de sistemas de partículas
        public ParticleSystem particulaActiva;
    public float velocidadProyectil = 8f;

    private void Update()
    {
        Vector3 posicionMouse = Input.mousePosition;
        Vector3 posicionMouseEnMundo = Camera.main.ScreenToWorldPoint(posicionMouse);

        // Definir una distancia inicial muy grande
        float distanciaMasCorta = Mathf.Infinity;
        ParticleSystem particulaMasCerca = null;

        // Encontrar la partícula más cercana al mouse
        for (int i = 0; i < particulas.Length; i++)
        {
            float distancia = Vector3.Distance(particulas[i].transform.position, posicionMouseEnMundo);
            if (distancia < distanciaMasCorta)
            {
                distanciaMasCorta = distancia;
                particulaMasCerca = particulas[i];
            }
        }

        // Activar la partícula más cercana y pausar las demás
        for (int i = 0; i < particulas.Length; i++)
        {
            if (particulas[i] == particulaMasCerca)
            {
                particulas[i].Play();
                particulas[i].gameObject.SetActive(true);
                particulaActiva = particulas[i]; // Actualizar la partícula activa
            }
            else
            {
                particulas[i].Pause();
                particulas[i].gameObject.SetActive(false);
            }
        }

        // Instanciar una copia de la partícula activa al hacer clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            ParticleSystem copiaParticula = Instantiate(particulaActiva, transform.position, Quaternion.identity);
            Vector3 direccion = (posicionMouseEnMundo - transform.position).normalized;
            copiaParticula.GetComponent<Rigidbody>().velocity = direccion * velocidadProyectil;
        }
    }
}
