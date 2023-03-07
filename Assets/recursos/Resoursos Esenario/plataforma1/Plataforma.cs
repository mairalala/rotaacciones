using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public bool WalterEnLaZona = false;
    public ParticleSystem RomperMuro;
    public float TiempoInicio = 1.0f;
    public float TiempoFin = 2.0f;

    private Vector3 ultimaPosicion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WalterEnLaZona = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WalterEnLaZona = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && WalterEnLaZona)
        {
            StartCoroutine(ActivarParticula());
        }
    }

    private IEnumerator ActivarParticula()
    {
        ultimaPosicion = GameObject.FindGameObjectWithTag("Player").transform.position;
        RomperMuro.transform.position = ultimaPosicion;

       

        yield return new WaitForSeconds(TiempoInicio);

        RomperMuro.gameObject.SetActive(true);
        RomperMuro.Play();



        yield return new WaitForSeconds(TiempoFin);

        RomperMuro.Stop();
        RomperMuro.gameObject.SetActive(false);

        GetComponent<Collider>().enabled = false;

        //  GetComponent<Collider>().enabled = true;
    }
}