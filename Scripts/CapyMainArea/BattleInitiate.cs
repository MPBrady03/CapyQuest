/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/22/24
******************/
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;
public class BattleInitiate : MonoBehaviour
{
      [SerializeField] private string battleSceneName; // Name of the battle scene

   private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")) // checks for player tag
    {
        GameManager.instance.StartBattle(battleSceneName);
    }
}

    private IEnumerator StartBattle() // makes use of a singleton to prevent any further initiations of a battle and if there was a previous battle saved, it is deleted before the new one is loaded.
    {
        // Load the battle scene asynchronously
        Debug.Log("Start Battle Called.");
        yield return SceneManager.LoadSceneAsync(battleSceneName);
        Debug.Log("Passed yield return scene loaded."); // debug logs to make sure battles are working correctly (they werent for so long).

        // Check if the BattleSystem instance exists and call StartBattle
        if (BattleSystem.instance != null)
        {
            Debug.Log("Calling BattleSystem.instance.StartBattle()");
            BattleSystem.instance.StartBattle();
        }
        else
        {
            Debug.LogError("BattleSystem instance not found!");
        }
    }
}

