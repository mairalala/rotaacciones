using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

public class ManagerPlaye : MonoBehaviour
{

    public ParticleSystem Estalla;
    public int contadorBombaTNTInicial = 0;
    public int contadorBombaTNT = 0;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    private Color colorOriginal;
    public bool BOM = false;
    //public bool TocaSuelo = false;
    [SerializeField] private Vector3[] _rotationsAnimations;
    [SerializeField] private Transform centroBomba;
    [SerializeField] private float radioBomba;
    [SerializeField] private LayerMask capaParedes;
    [SerializeField] private LayerMask capaPiso;
    public int posActualPie;

    [SerializeField] public Collider[] pies;

    [SerializeField] bool _tocandoSuelo;
    [SerializeField] LayerMask _capasPiso;

    public bool TocandoSuelo { get => _tocandoSuelo; set => _tocandoSuelo = value; }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tnt"))
        {
            AumentarBombaTNT();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && contadorBombaTNT >= 1)
        {
            DisminuirBombaTNT();
            Debug.Log("LoHaceCorrutina");
            StartCoroutine(BomTnt());
        }
    }
    //if (Input.GetKeyDown(KeyCode.D))
    //{
    //    posicionActualPie++;
    //    if (posicionActualPie >= pies.Length)
    //    {
    //        posicionActualPie = 0;
    //    }
    //for (int i = 0; i < pies.Length; i++)
    //{
    //    if (i == posicionActualPie)
    //    {
    //        pies[i].SetActive(true);
    //    }
    //    else
    //    {
    //        pies[i].SetActive(false);
    //    }
    //}
    //    }
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        posicionActualPie--;
    //        if (posicionActualPie < 0)
    //        {
    //            posicionActualPie = pies.Length - 1;
    //        }
    //        for (int i = 0; i < pies.Length; i++)
    //        {
    //            if (i == posicionActualPie)
    //            {
    //                pies[i].SetActive(true);
    //            }
    //            else
    //            {
    //                pies[i].SetActive(false);
    //            }
    //        }
    //    }
    //}
    private void Start()
    {
        contadorBombaTNT = contadorBombaTNTInicial;
        colorOriginal = GetComponentInChildren<MeshRenderer>().materials[0].color;

        ActivarPies(0);
    }

    public IEnumerator BomTnt()
    {
        yield return new WaitForSeconds(0.1f);
        objectThree.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        objectThree.SetActive(false);
        yield return new WaitForSeconds(0.2f);

        objectTwo.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        objectTwo.SetActive(false);
        objectOne.SetActive(true);

        yield return new WaitForSeconds(1.1f);
        objectOne.SetActive(false);

        Explosion();
    }


    public void Explosion()
    {
        Collider[] objetosColisionados = Physics.OverlapSphere(centroBomba.position, radioBomba, capaParedes);

        if (objetosColisionados.Length > 0)
        {
            for (int i = 0; i < objetosColisionados.Length; i++)
            {
                objetosColisionados[i].GetComponent<Plataform>().Destruir();
            }
        }
        else
        {
            Debug.Log("No detecte nada");
        }
    }
    public void DisminuirBombaTNT()
    {
        if (contadorBombaTNT >= 1)
        {
            contadorBombaTNT--;
        }
    }

    public void AumentarBombaTNT()
    {
        contadorBombaTNT++;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centroBomba.position, radioBomba);

        //void DrawGizmoFrente()
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireCube(FrentecontroladorSuelo.position, FrentedimensionesCaja);
        //}

        //void DrawGizmoArriba()
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireCube(ArribacontroladorSuelo.position, ArribadimensionesCaja);
        //}

        //void DrawGizmoAtras()
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireCube(AtrascontroladorSuelo.position, AtrasdimensionesCaja);
        //}

    }

    public void ActivarPies(int currentRotation)
    {
        for (int i = 0; i < pies.Length; i++)
        {
            if (i == currentRotation)
            {
                pies[i].enabled = true;
            }

            else
            {
                pies[i].enabled = false;
            }
        }
    }
    public void DisminuirPosicion()
    {
        Debug.Log("rotonumeros");
        posActualPie--;
        if (posActualPie <= -1)
        {
            {

                posActualPie = 3;
            }
        }
    }
    public void AumentarPosicion()
    {
        Debug.Log("rotonumeros");
        posActualPie++;
        if (posActualPie > _rotationsAnimations.Length)
        {
            posActualPie = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log(other.gameObject.layer);

            if (other.gameObject.layer == _capasPiso)
            {
                _tocandoSuelo = true;
            }
        }

        else
        {
            _tocandoSuelo = false;
        }
    }
    public void Rotaranimaciones()
    {
        //Debug.Log("rotonumeros");
        //Vector3 newRotation = _rotationsAnimations[posActualPie]; // Obtenemos los ángulos de euler de la rotación deseada
        //objectOne.transform.rotation = Quaternion.Euler(new Vector3(newRotation.x, newRotation.y, objectOne.transform.rotation.eulerAngles.z));
        //objectTwo.transform.rotation = Quaternion.Euler(new Vector3(newRotation.x, newRotation.y, objectTwo.transform.rotation.eulerAngles.z));
        //objectThree.transform.rotation = Quaternion.Euler(new Vector3(newRotation.x, newRotation.y, objectThree.transform.rotation.eulerAngles.z));
    }
}









