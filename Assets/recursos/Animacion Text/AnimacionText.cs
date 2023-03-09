using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimacionText : MonoBehaviour
{
    string frase = "Giro_en_el_Laverinto es un juego entretenido deberas oprimir   A o b ";
    public TextMeshProUGUI TextoAnimado;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }
    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            TextoAnimado.text = TextoAnimado.text + caracter;
            yield return new WaitForSeconds(0.020f);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
