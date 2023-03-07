using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

public class ManagerPlaye : MonoBehaviour
{
    public int contadorBombaTNTInicial = 0;
    public int contadorBombaTNT = 0;
    //public int contadorBombaNitroInicial = 0;
    //public int contadorBombaNitro = 0;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    private Color colorOriginal;
    public bool BOM = false;

    [SerializeField] Transform centroBomba;
    [SerializeField] float radioBomba;
    [SerializeField] LayerMask capaParedes;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tnt"))
        {
            AumentarBombaTNT();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && contadorBombaTNT >= 1) 
        
        {
            DisminuirBombaTNT();
            Debug.Log("LoHaceCorrutina");
            StartCoroutine(BomTnt());
        }
    }
    void Start()
    {
        contadorBombaTNT = contadorBombaTNTInicial;
        //GameObject carasNegras = transform.Find("carasnegras").gameObject;
        //MeshRenderer[] meshRenderers = carasNegras.GetComponentsInChildren<MeshRenderer>()
        //                                         .Where(mr => mr.gameObject.name != "Centro")
        //                                         .ToArray();
        //colorOriginal = meshRenderers[0].materials[0].color;
    }
    //MeshRenderer[] meshRendere
    public IEnumerator BomTnt()
    {
        //BOM = false;
        // BOM = true;
        // meshRenderers.ToList().ForEach(mr => mr.materials[1].color = Color.yellow);
        yield return new WaitForSeconds(0.1f);
        objectThree.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        objectThree.SetActive(false);
        //meshRenderers.ToList().ForEach(mr => mr.materials[1].color = new Color(1f, 0.5f, 0f));
        yield return new WaitForSeconds(0.2f);

        objectTwo.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        objectTwo.SetActive(false);
        objectOne.SetActive(true);

        //meshRenderers.ToList().ForEach(mr => mr.materials[1].color = Color.yellow);
        yield return new WaitForSeconds(1.1f);
        //meshRenderers.ToList().ForEach(mr => mr.materials[1].color = colorOriginal);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centroBomba.position, radioBomba);
    }
}
