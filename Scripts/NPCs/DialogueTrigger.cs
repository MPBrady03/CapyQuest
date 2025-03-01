/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
12/5/24
Credit to Brackeys for help with Dialogue: https://www.youtube.com/watch?v=_nRzoTzeyxU
******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue (){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}