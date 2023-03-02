using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;


public class color : MonoBehaviour
{
    public Color[] colores;
    public Queue<color> QueueColor = new Queue<color>();
    //public Material colores_;
    public SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        foreach (Color c in colores)
        {
            QueueColor.Enqueue(c);
        }

        StartCoroutine(cambio());
    }

    // Update is called once per frame
    void Update()
    {
        // barrera.GetComponent<Renderer>().materials[0].color = Random.ColorHSV();

    }

    IEnumerator cambio()
    {
        yield return new WaitForSeconds(3f);
        
    }
}
