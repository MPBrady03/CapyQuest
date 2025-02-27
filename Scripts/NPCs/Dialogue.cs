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

[System.Serializable]
public class Dialogue 
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
