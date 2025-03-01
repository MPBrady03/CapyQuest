/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/22/24
******************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance; // Singleton instance

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // prevent destruction of main capybara.
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances of main capybara
        }
    }

    // Instance method 
    public async void StartBattle()
    {
        Debug.Log("Battle Started!"); // checks if the battle has started
        await InstanceBattle();
    }

    // test for making battles start and end, for debugging
    private async Task InstanceBattle()
    {
        await Task.Delay(5000); // Simulate battle duration
        EndBattle();
    }

    private void EndBattle()
    {
        Debug.Log("Ending battle and loading original scene..."); // debug for ending battle correctly
        SceneManager.LoadScene("OpenWorld1"); // loads the previous scene area
    }
}