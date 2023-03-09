using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entradasysalidas : MonoBehaviour
{
    [SerializeField] private GameObject CinferiorIzquierda;
    [SerializeField] private GameObject CcentroBajo;
    [SerializeField] private GameObject CinferioDerecha;
    [SerializeField] private GameObject CMitadIzquierda;
    [SerializeField] private GameObject CmitadCentro;
    [SerializeField] private GameObject CmitadDerecho;
    [SerializeField] private GameObject CsuperioriorIzquierda;
    [SerializeField] private GameObject Csuperiorcentro;
    [SerializeField] private GameObject CsuperiorDerecho;



    [SerializeField] private GameObject cuboLLega1;
    [SerializeField] private GameObject cuboLLega2;
    [SerializeField] private GameObject cuboLLega3;

    [SerializeField] private Transform[] PosicionesLlegada;
    [SerializeField] private Transform LLegadaPortal;
    [SerializeField] private Transform SalidaPortal;
    [SerializeField] private Transform Posicionitemnfinal;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LLeganLasParticulas());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LLeganLasParticulas()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            int posicionLlegadaIndex = Random.Range(0, PosicionesLlegada.Length);
            cuboLLega1.transform.position = PosicionesLlegada[posicionLlegadaIndex].position;
            cuboLLega1.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            int caraIndex = Random.Range(0, 3);
            GameObject caraObjetivo = null;
            switch (caraIndex)
            {
                case 0:
                    caraObjetivo = CinferiorIzquierda;
                    break;
                case 1:
                    caraObjetivo = CcentroBajo;
                    break;
                case 2:
                    caraObjetivo = CinferioDerecha;
                    break;
            }
            float elapsedTime = 0f;
            Vector3 startingPos = cuboLLega1.transform.position;
            Vector3 targetPos = caraObjetivo.transform.position;
            while (elapsedTime < 0.5f)
            {
               cuboLLega1.transform.position = Vector3.MoveTowards(startingPos, targetPos, elapsedTime / 0.5f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            cuboLLega1.SetActive(false);
        }
    }
    public IEnumerator EntraAlPortal()
    {
        yield return new WaitForSeconds(0.1f);

        // Obtiene una posición aleatoria entre 0 y 4 (5 opciones en total)
        int posicionLlegadaIndex = Random.Range(0, 5);

        // Inicializa la variable lugarObjetivo a null
        GameObject lugarObjetivo = null;

        // Según la posición aleatoria obtenida, se asigna un lugar objetivo
        switch (posicionLlegadaIndex)
        {
            case 0:
                lugarObjetivo = CMitadIzquierda;
                break;
            case 1:
                lugarObjetivo = CmitadCentro;
                break;
            case 2:
                lugarObjetivo = CmitadDerecho;
                break;
            case 3:
                lugarObjetivo = CsuperioriorIzquierda; 
                break;
            case 4:
                lugarObjetivo = Csuperiorcentro;
                ; break;
            case 5:
                lugarObjetivo = CsuperiorDerecho;
                break;
        }

        // Obtiene la posición actual del cubo que llegará al objetivo
        Vector3 startingPos = cuboLLega1.transform.position;

        // Obtiene la posición del objetivo al que el cubo debe llegar
        Vector3 targetPos = lugarObjetivo.transform.position;

        // Inicializa el tiempo transcurrido a cero
        float elapsedTime = 0f;

        // Realiza el movimiento del cubo desde su posición actual hasta el objetivo
        while (elapsedTime < 0.5f)
        {
            cuboLLega1.transform.position = Vector3.MoveTowards(startingPos, targetPos, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Desactiva el objeto cuboLLega1 para que desaparezca
        cuboLLega1.SetActive(false);
    }
}
