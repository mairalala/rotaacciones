using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

public class ManagerPlayer : MonoBehaviour
{
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    private Color colorOriginal;
    private bool BOM = false;

    void Start()
    {
        GameObject carasNegras = transform.Find("carasnegras").gameObject;
        //MeshRenderer[] meshRenderers = carasNegras.GetComponentsInChildren<MeshRenderer>()
        //                                         .Where(mr => mr.gameObject.name != "Centro")
        //                                         .ToArray();
        //colorOriginal = meshRenderers[0].materials[0].color;
    }

    public IEnumerator BomTnt(MeshRenderer[] meshRenderers)
    {
        BOM = true;
        meshRenderers.ToList().ForEach(mr => mr.materials[1].color = Color.yellow);
        yield return new WaitForSeconds(0.1f);
        objectThree.SetActive(true);
        meshRenderers.ToList().ForEach(mr => mr.materials[1].color = new Color(1f, 0.5f, 0f));
        yield return new WaitForSeconds(1.9f);
        objectTwo.SetActive(true);
        yield return new WaitForSeconds(2.7f);
        objectOne.SetActive(true);
        meshRenderers.ToList().ForEach(mr => mr.materials[1].color = Color.yellow);
        yield return new WaitForSeconds(0.56f);
        meshRenderers.ToList().ForEach(mr => mr.materials[1].color = colorOriginal);
        BOM = false;
    }

    internal IEnumerator BomTnt()
    {
        throw new NotImplementedException();
    }
}
