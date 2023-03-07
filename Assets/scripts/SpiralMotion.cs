using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMotion : MonoBehaviour
{
    public float radius = 1.0f;     // radio del c�rculo
    public float speed = 1.0f;      // velocidad de rotaci�n (en este caso, negativa)
    private float angle = 0.0f;     // �ngulo actual
    private Vector3 startPos;       // posici�n inicial
    public bool seguirPosicion;     // seguir la posici�n de PosPortal
    public Transform PosPortal;     // objeto cuya posici�n se seguir�

    private Vector3 posActual;      // posici�n actual del objeto
    private float anguloInicial;    // �ngulo inicial cuando el objeto comienza a seguir la posici�n de PosPortal

    void Start()
    {
        // Guardamos la posici�n inicial del objeto
        startPos = transform.position;
    }

    void Update()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        if (seguirPosicion)
        {
            // Si la variable seguirPosicion es verdadera, actualizamos la posici�n del objeto a la posici�n de PosPortal
            sPos();
        }
        else
        {
            // Si la variable seguirPosicion es falsa, el objeto rota en forma circular en su posici�n actual
            // Incrementamos el �ngulo con el tiempo
            angle += Time.deltaTime * speed;

            // Calculamos la posici�n del objeto en el c�rculo
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            float z = 0.0f;             // La posici�n Z es 0 para limitar al plano XY
            Vector3 pos = new Vector3(x, y, z);

            // Movemos el objeto a su nueva posici�n en el c�rculo
            transform.position = posActual + pos;
        }
    }

    // Funci�n que actualiza la posici�n del objeto en base a la posici�n de PosPortal
    void sPos()
    {
        // Si es la primera vez que se sigue la posici�n de PosPortal, guardamos la posici�n actual del objeto y el �ngulo inicial
        if (posActual == Vector3.zero)
        {
            posActual = transform.position;
            anguloInicial = angle;
        }

        // Incrementamos el �ngulo con el tiempo
        angle += Time.deltaTime * speed;

        // Calculamos la posici�n del objeto en el c�rculo
        float x = radius * Mathf.Cos(angle - anguloInicial);
        float y = radius * Mathf.Sin(angle - anguloInicial);
        float z = 0.0f;             // La posici�n Z es 0 para limitar al plano XY
        Vector3 pos = new Vector3(x, y, z);

        // Movemos el objeto a su nueva posici�n en el c�rculo
        transform.position = PosPortal.position + pos;
    }
}



