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
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour// runs dialogue in a queue so that the text is displayed in order until the queue is empty.
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogueText;
    public Animator animator;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue){
        animator.SetBool("isOpen", true);
        NameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence){
        DialogueText.text ="";
        foreach (char letter in sentence){
            DialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(){
        animator.SetBool("isOpen", false);
    }
}
