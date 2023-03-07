using System.Collections;
using UnityEngine;
using TMPro;
using System;


public class RecolecionItemn : MonoBehaviour
{

    public int contadorBombaTNTInicial = 0;
    public int contadorBombaTNT = 0;
    public TextMeshProUGUI contadorTexto;
    public int contadorBombaNitroInicial = 0;
    public int contadorBombaNitro = 0;
    public TextMeshProUGUI contadorNitroTexto;
    public float tiempoEsperaParticula = 3.41f;
    //public GameObject ManagerP;
    //public ManagerPlayer managerPlayer;
    //public ManagerPlataforma managerPlataforma;
    //public GameObject ManagerPlataforma;
    public GameObject managerP;
    public GameObject Plataforma;
    public float tiempoEspera = 0.1f; // tiempo de espera para ActivarParticula
    void Start()
    {
        //GameObject Plataforma = GameObject.FindWithTag("ManagerPlataform");


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

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && contadorBombaTNT >= 1)


            //{
            //    if (managerP != null)
            //    {
            //        Debug.Log("LoHaceCorrutina");
            //        StartCoroutine(EsperarYLlamarBomTnt(managerP));
            //    }

            //    // Llamar a la corrutina ActivarParticula del script Plataforma en el objeto ManagerPlataforma
            //    //if (managerPlataforma != null)
            //    //{
            //    //    StartCoroutine(EsperarYLlamarActivarParticula(managerPlataforma.plataform));
            //    //}
            //}void Update()

            // Plataforma.GetComponent<Plataform>().StartCoroutine("ActivarParticula");
            //if (Input.GetKeyDown(KeyCode.R) && contadorBombaTNT >= 1)
            //{
            //    ManagerPlataforma manager = FindObjectOfType<ManagerPlataforma>();
            //    manager.StartCoroutine(manager.ActivarParticula());

            if (managerP != null)
            {
                DisminuirBombaTNT();
                Debug.Log("LoHaceCorrutina");
                StartCoroutine(managerP.GetComponent<ManagerPlaye>().BomTnt());
            }





        // Verificar si la tecla F es presionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisminuirBombaNitro();
        }
    }

    internal int ContadorBombaTNT()
    {
        throw new NotImplementedException();
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

    //private IEnumerator EsperarYLlamarBomTnt(ManagerP)
    //{
    //    yield return new WaitForSeconds(tiempoEspera);

    //    managerPlayer.BomTnt();
    //}


    /*public IEnumerator EsperarYLlamarActivarParticula(Plataform plataforma)
    {
        yield return new WaitForSeconds(tiempoEsperaParticula);

        plataforma.Destruir();
    }*/
}