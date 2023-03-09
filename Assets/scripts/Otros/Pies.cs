using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    [SerializeField] private LayerMask capaParedes;
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en contacto con el jugador está en la capa de paredes
        if ((capaParedes.value & (1 << other.gameObject.layer)) > 0)
        {
            // Llamar al método EstaEnSuelo() del objeto con el tag "World" y el componente StageRotation
            GameObject worldObject = GameObject.FindWithTag("World");
            if (worldObject != null)
            {
                StageRotation stageRotation = worldObject.GetComponent<StageRotation>();
                if (stageRotation != null)
                {
                    stageRotation.EstaEnSuelo();
                }
                else
                {
                    Debug.LogError("No se pudo encontrar el componente StageRotation en el objeto con el tag World.");
                }
            }
            else
            {
                Debug.LogError("No se pudo encontrar el objeto con el tag World.");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {// Verificar si el objeto que entró en contacto con el jugador está en la capa de paredes
        if ((capaParedes.value & (1 << other.gameObject.layer)) > 0)
        {
            // Llamar al método EstaEnSuelo() del objeto con el tag "World" y el componente StageRotation
            GameObject worldObject = GameObject.FindWithTag("World");
            if (worldObject != null)
            {
                StageRotation stageRotation = worldObject.GetComponent<StageRotation>();
                if (stageRotation != null)
                {
                    stageRotation.SinSuelo();
                }
                else
                {
                    Debug.LogError("No se pudo encontrar el componente StageRotation en el objeto con el tag World.");
                }
            }
            else
            {
                Debug.LogError("No se pudo encontrar el objeto con el tag World.");
            }
        }
    }
}


