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
            // Llamar a la funci�n "AumentarBombaTNT" en el componente "RecoleccionItemn" del objeto padre
            recoleccionItemn.AumentarBombaTNT();

            // Desactivar la part�cula p�blica "parpadeo"
            parpadeo.gameObject.SetActive(false);

            // Desactivar la part�cula p�blica "cuadro"
            parpadeo.gameObject.SetActive(false);
        }
        else
        {
            // Mostrar una advertencia en la consola si el objeto padre no tiene el componente "RecoleccionItemn"
            Debug.LogWarning("El objeto padre no tiene el componente 'RecoleccionItemn'");
        }
    }
}
