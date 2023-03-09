using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RotacionAparese : MonoBehaviour
{
    [SerializeField] private Vector3 RotacionInicial;
    public ParticleSystem Cuadrito;
    public ParticleSystem CuadritoNegro;
    private float timer = 0f;
    private bool isRotating = false;
    private Quaternion targetRotation;
    public float _rotationSpeed = 5f;
    public Vector3 blanco;
    public float tiempoDeGirar = 0.2f;
    [SerializeField] private ParticleSystem cudritoCrece;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject spriteNegro;
    public MeshRenderer meshRenderer;
    public Vector3 naranjaPosition = new Vector3(1f, 0.5f, 0f);
    public bool Inicio = false;

    private void Start()
    {
        Cuadrito.Stop();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Inicio)
        {

            StartCoroutine(_laParticula());

        }
        //    if (isRotating)
        //    {
        //        Cuadrito.Play();
        //        // Rotating the object in the Y axis by -90 degrees using Quaternion.Euler()
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(blanco), _rotationSpeed);
        //        if (transform.rotation == Quaternion.Euler(blanco))
        //        {
        //            Cuadrito.Stop();
        //            isRotating = false;
        //        }
        //    }
        //    else
        //    {
        //        timer += Time.deltaTime;
        //        if (timer >= tiempoDeGirar)
        //        {
        //            isRotating = true;
        //            timer = 0f;
        //        }
        //    }
        //}
    }
    IEnumerator RotatandoNegro()
    {
        RotacionInicial = transform.rotation.eulerAngles;
        cudritoCrece.Play();
        Cuadrito.Play(); 
            yield return new WaitForSeconds(0.25f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(blanco), _rotationSpeed);
        // Rotating the object in the Y axis by -90 degrees using Quaternion.Euler()
        yield return new WaitForSeconds(0.3f);
        cudritoCrece.Stop();

   
            if (transform.rotation == Quaternion.Euler(blanco))
            {
                yield return new WaitForSeconds(tiempoDeGirar - 0.3f);
            }
            else
            {
                yield return null;
            }
    }
    private IEnumerator _laParticula()
    {
        cudritoCrece.Play();
        yield return new WaitForSeconds(0.3f);
        cudritoCrece.Stop();
    }

    private IEnumerator parpadeoSpriteBlanco()
    {
        while (true)
        {
            sprite.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            sprite.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator parpadeoSpriteNegro()
    {
        while (true)
        {
            spriteNegro.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            spriteNegro.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator Rotatandoblanco()
    {
        // Activar la partícula Cuadrito después de 0.25 segundos
        yield return new WaitForSeconds(0.25f);
        CuadritoNegro.Play();

        // Rotar el objeto hacia RotacionInicial
        while (transform.rotation != Quaternion.Euler(RotacionInicial))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(RotacionInicial), _rotationSpeed);
            yield return null;
        }

        // Esperar y luego desactivar la partícula Cuadrito
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(tiempoDeGirar - 0.3f);
        CuadritoNegro.Stop();
    }
    IEnumerator Rojo()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Color originalColor = meshRenderer.materials[1].color; // Color original del elemento 1

        // Cambiar a naranja en 0.1 segundos
        meshRenderer.materials[1].color = Color.Lerp(originalColor, new Color(naranjaPosition.x, naranjaPosition.y, naranjaPosition.z), 0.1f);
        yield return new WaitForSeconds(0.1f);

        // Cambiar a rojo en 0.3 segundos
        meshRenderer.materials[1].color = Color.Lerp(meshRenderer.materials[1].color, Color.red, 0.3f);
        yield return new WaitForSeconds(0.3f);

        // Cambiar a naranja en 0.2 segundos
        meshRenderer.materials[1].color = Color.Lerp(meshRenderer.materials[1].color, new Color(naranjaPosition.x, naranjaPosition.y, naranjaPosition.z), 0.2f);
        yield return new WaitForSeconds(0.2f);

        // Volver al color original en 0.1 segundos
        meshRenderer.materials[1].color = Color.Lerp(meshRenderer.materials[1].color, originalColor, 0.1f);
    }
}



