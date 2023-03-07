using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAparese : MonoBehaviour
{
    public ParticleSystem Cuadrito;
    private float timer = 0f;
    private bool isRotating = false;
    private Quaternion targetRotation;
    public float _rotationSpeed = 5f;
    public Vector3 blanco;
    public float tiempoDeGirar = 0.2f;

    private void Start()
    {
        Cuadrito.Stop();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            Cuadrito.Play();
            // Rotating the object in the Y axis by -90 degrees using Quaternion.Euler()
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(blanco), _rotationSpeed);
            if (transform.rotation == Quaternion.Euler(blanco))
            {
                Cuadrito.Stop();
                isRotating = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= tiempoDeGirar)
            {
                isRotating = true;
                timer = 0f;
            }
        }
    }
}
