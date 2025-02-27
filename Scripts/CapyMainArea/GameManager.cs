/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/22/24
******************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour // this class stores data for the current scene and is in charge of delivering information to and from the other scenes
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    public void StartBattle(string battleSceneName)
    {
        StartCoroutine(LoadBattleScene(battleSceneName)); // loads the battle scene
    }

    private IEnumerator LoadBattleScene(string battleSceneName)
    {
        yield return SceneManager.LoadSceneAsync(battleSceneName);
        Debug.Log("Battle scene loaded.");

        // Call BattleSystem if it exists
        if (BattleSystem.instance != null)
        {
            Debug.Log("Calling BattleSystem.instance.StartBattle()");
            BattleSystem.instance.StartBattle(); // loads the battle scene asynchronously and then calls StartBattle().
        }
    }

    public void ReturnToOriginalScene(string originalSceneName)
    {
        StartCoroutine(LoadOriginalScene(originalSceneName)); // loads the previous scene after battle completion
    }

    private IEnumerator LoadOriginalScene(string originalSceneName)
    {
        yield return SceneManager.LoadSceneAsync(originalSceneName);
        Debug.Log("Returning to original scene.");
    }
}