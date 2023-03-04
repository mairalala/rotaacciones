using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecolecionItemn : MonoBehaviour
{

    public int contadorBombaTNTInicial = 0;
    public int contadorBombaTNT = 0;
    public TextMeshProUGUI contadorTexto;
    public int contadorBombaNitroInicial = 0;
    public int contadorBombaNitro = 0;
    public TextMeshProUGUI contadorNitroTexto;
    void Update()
    {
        // Verificar si la tecla R es presionada
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisminuirBombaTNT();
        }

        // Verificar si la tecla F es presionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisminuirBombaNitro();
        }
    }

    void Start()
    {
        contadorBombaTNT = contadorBombaTNTInicial;
        contadorBombaNitro = contadorBombaNitroInicial;

        if (contadorTexto != null)
        {
            contadorTexto.text = contadorBombaTNT.ToString();
        }
        

        if (contadorNitroTexto != null)
        {
            contadorNitroTexto.text = contadorBombaNitro.ToString();
        }
    }

    public void DisminuirBombaTNT()
    {
        if (contadorBombaTNT >= 1)
        {
            contadorBombaTNT--;
            if (contadorTexto != null)
            {
                contadorTexto.text = contadorBombaTNT.ToString();
            }
        }
    }

    public void AumentarBombaTNT()
    {
        contadorBombaTNT++;
        if (contadorTexto != null)
        {
            contadorTexto.text = contadorBombaTNT.ToString();
            Debug.Log("rECOGIObOMB");
        }
    }
    public void AumentarBombaNitro()
    {
        contadorBombaNitro++;
        if (contadorNitroTexto != null)
        {
            contadorNitroTexto.text = contadorBombaNitro.ToString();
        }
    }
    public void DisminuirBombaNitro()
    {
        if (contadorBombaNitro >= 1)
        {
            contadorBombaNitro--;
            if (contadorNitroTexto != null)
            {
                contadorNitroTexto.text = contadorBombaNitro.ToString();
            }
        }
    }
}