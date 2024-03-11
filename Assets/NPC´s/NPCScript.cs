using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, IDialogable
{
    //TP2 Marques

    public string[] linesNpc;
    public DialogosScript myDialogues;
    int index;
    public GameObject panelDialogos;
    public EmpathyManager reference;
    public float myEmpathy;
    public Canvas npcs;
    public delegate void dialogueSystem();
    public dialogueSystem dialogues;

    private void Update()
    {
        index = myDialogues.index;             
    }
    void Start()
    {
        dialogues = CallMeDialogues;
    }

    void CallMeDialogues()
    {
        myDialogues.myNpc = this;
        panelDialogos.gameObject.SetActive(true);
        myDialogues.lines = linesNpc;
        myDialogues.dialogueText.text = string.Empty;
        myDialogues.StartDialogue();
        dialogues = ContinueMeDialogues;
    }

    void ContinueMeDialogues()
    {
        if (myDialogues.dialogueText.text == myDialogues.lines[index])
        {
            myDialogues.NextLine();
        }
        else 
        {
            myDialogues.StopAllCoroutines();
            myDialogues.dialogueText.text = myDialogues.lines[index];
        }
        
    }

    public void MoreEmpathy()
    {
        reference.PlusEmpathy(myEmpathy);
    }

    
}
