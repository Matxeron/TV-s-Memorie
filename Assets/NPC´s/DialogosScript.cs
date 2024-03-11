using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogosScript : MonoBehaviour
{
    //TP2 Marques Vintar
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float speedText = 0.1f;
    public int index;
    public GameObject panelDialogos;
    public NPCScript myNpc;


    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());

    }
    
    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            panelDialogos.gameObject.SetActive(false);
            myNpc.MoreEmpathy();
        }
    }

}
