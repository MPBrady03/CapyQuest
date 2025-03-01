/************
Braeden Kurfman
Capstone Computing Project
Capy Quest
10/22/24
(last updated 2/28/25)
************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // initializes variables to be editable in Unity for testing.
    public string unitName; // Name of character (Need to add ability for players to add names to playable character)
    public int unitLevel; // Current unit level (need to add maximum level for balancing)
    public int currentHP; // current health based off of total damage taken
    public int maxHP; // maximum health for character
    public int damage; // the amount of damage this character can do
    public int speed; // determines who goes first and in what order
    public int luck; // a value that if landed under by a random number generator increases damage by 1.5 times

    public bool takeDamage(int dmg){ // calculate damage based on stats and current health.
        currentHP -= dmg;
        if(currentHP <= 0){
            return true;
        }
        else{
            return false;
        }
    }
}

