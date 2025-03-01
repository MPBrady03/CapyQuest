/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/22/24
******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBattle1 : MonoBehaviour
{
    public AudioSource audioSource; // Plays the background battle music

    void Start()
    {
        audioSource.Play();
    }
}
