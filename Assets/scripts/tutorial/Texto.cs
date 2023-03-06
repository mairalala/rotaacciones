using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    public GameObject texto;

    private void Start()
    {
        texto.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            texto.SetActive(true);
            StartCoroutine("waitForSec");
        }
    }

    IEnumerator waitForSec()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(texto);
        Destroy(gameObject);
    }
}
