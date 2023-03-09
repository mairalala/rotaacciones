using System.Collections;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    public ParticleSystem parpadeo;
    public ParticleSystem cuadito;

    void OnTriggerEnter(Collider other)
    {
        // Obtener el objeto padre del objeto actual que tiene el script "Bomb"
        GameObject parentObject = transform.parent.gameObject;

        // Buscar el componente "RecoleccionItemn" en el objeto padre
        RecolecionItemn recoleccionItemn = parentObject.GetComponent<RecolecionItemn>();
        if (recoleccionItemn != null)
        {
            // Llamar a la función "AumentarBombaTNT" en el componente "RecoleccionItemn" del objeto padre
            recoleccionItemn.AumentarBombaTNT();

            // Iniciar la corrutina "DesapareceItem"
            StartCoroutine(DesapareceItem());
        }
        else
        {
            // Mostrar una advertencia en la consola si el objeto padre no tiene el componente "RecoleccionItemn"
            Debug.LogWarning("El objeto padre no tiene el componente 'RecoleccionItemn'");
        }
    }

    IEnumerator DesapareceItem()
    {
        // Esperar 0.2 segundos
        yield return new WaitForSeconds(0.1f);

        // Desactivar la partícula pública "parpadeo"
        parpadeo.gameObject.SetActive(false);

        // Esperar 0.3 segundos adicionales
        yield return new WaitForSeconds(0.2f);

        // Desactivar la partícula pública "cuadito"
        cuadito.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}

