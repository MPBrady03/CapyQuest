using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCapyBattle : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int supportCapyLevel;
    public string supportCapyName;

    public HealthBarScript healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.setHealth(currentHealth);
    }
}
  
