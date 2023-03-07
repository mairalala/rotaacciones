using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Texto : MonoBehaviour
{
    public TextMeshProUGUI dialogostexto;
    public string[] lines;
    public float textSpeed = 0.1f;
    int index;
    private void Start()
    {
        dialogostexto.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (dialogostexto.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogostexto.text = lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }
    IEnumerator WriteLine()
    {
        foreach (char Letter in lines[index].ToCharArray())
        {
            dialogostexto.text += Letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogostexto.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
