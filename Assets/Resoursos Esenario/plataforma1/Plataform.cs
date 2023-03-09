using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plataform : MonoBehaviour
{
    //public bool Estallido = false;
    public ParticleSystem RomperMuro;
    public float TiempoInicio = 3.1f;
    public float TiempoMitad = 0.1f;
    public float TiempoFin = 0.2f;

    private Vector3 ultimaPosicion;
    Collider collision;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Estallido = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Estallido = false;
    //    }
    //}

    private void Start()
    {
        collision = GetComponent<Collider>();
    }
    public void Destruir()
    {
        Transform PosParticulaRompeMuro = GameObject.FindGameObjectWithTag("Plataforma").transform.Find("PosParticulaRompeMuro");
        ultimaPosicion = PosParticulaRompeMuro.position;
        RomperMuro.transform.position = ultimaPosicion;
        RomperMuro.gameObject.SetActive(true);
        //RomperMuro.Play();
        collision.enabled = false;
        //GgameObject.SetActive = false;
    }
    //public IEnumerator ActivarParticula()
    //{
    //    //if (Estallido)
    //    //{
    //    Debug.Log("enrutina");
    //    // Obtiene el objeto hijo "PosParticulaRompeMuro" del jugador y guarda su posición como la última posición
        



    //    // Mueve la posición de la partícula a la última posición

      

    //   // yield return new WaitForSeconds(TiempoInicio);



      

    //    yield return new WaitForSeconds(TiempoMitad);
    //    //transform.Find("Plataforma").GetComponent<Collider>().enabled = false;
    //    //transform.Find("Plataforma").gameObject.SetActive(false);


    //    yield return new WaitForSeconds(TiempoFin);

    //    RomperMuro.Stop();
    //    RomperMuro.gameObject.SetActive(false);


    //    // Disminuye el contador de bombas TNT en el script "RecoleccionItem"
    //    // GameObject.Find("ManagerItemns").GetComponent<RecolecionItemn>().DisminuirBombaTNT();
    //    //}
    //}
}





