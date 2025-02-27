
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Prevents destruction of player and helps to maintain player's items
public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public Vector3 spawnPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}