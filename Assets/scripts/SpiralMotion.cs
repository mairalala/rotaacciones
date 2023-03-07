using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMotion : MonoBehaviour
{
    public float radius = 1.0f;     // radio del círculo
    public float speed = 1.0f;      // velocidad de rotación (en este caso, negativa)
    private float angle = 0.0f;     // ángulo actual
    private Vector3 startPos;       // posición inicial
    public bool seguirPosicion;     // seguir la posición de PosPortal
    public Transform PosPortal;     // objeto cuya posición se seguirá

    private Vector3 posActual;      // posición actual del objeto
    private float anguloInicial;    // ángulo inicial cuando el objeto comienza a seguir la posición de PosPortal

    void Start()
    {
        // Guardamos la posición inicial del objeto
        startPos = transform.position;
    }

    void Update()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        if (seguirPosicion)
        {
            // Si la variable seguirPosicion es verdadera, actualizamos la posición del objeto a la posición de PosPortal
            sPos();
        }
        else
        {
            // Si la variable seguirPosicion es falsa, el objeto rota en forma circular en su posición actual
            // Incrementamos el ángulo con el tiempo
            angle += Time.deltaTime * speed;

            // Calculamos la posición del objeto en el círculo
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            float z = 0.0f;             // La posición Z es 0 para limitar al plano XY
            Vector3 pos = new Vector3(x, y, z);

            // Movemos el objeto a su nueva posición en el círculo
            transform.position = posActual + pos;
        }
    }

    // Función que actualiza la posición del objeto en base a la posición de PosPortal
    void sPos()
    {
        // Si es la primera vez que se sigue la posición de PosPortal, guardamos la posición actual del objeto y el ángulo inicial
        if (posActual == Vector3.zero)
        {
            posActual = transform.position;
            anguloInicial = angle;
        }

        // Incrementamos el ángulo con el tiempo
        angle += Time.deltaTime * speed;

        // Calculamos la posición del objeto en el círculo
        float x = radius * Mathf.Cos(angle - anguloInicial);
        float y = radius * Mathf.Sin(angle - anguloInicial);
        float z = 0.0f;             // La posición Z es 0 para limitar al plano XY
        Vector3 pos = new Vector3(x, y, z);

        // Movemos el objeto a su nueva posición en el círculo
        transform.position = PosPortal.position + pos;
    }
}



