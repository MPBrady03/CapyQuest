/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/28/24
******************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    // Detect when the player enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks for Player Tag
        if (other.CompareTag("Player"))
        {
            // Load the scene
            SceneManager.LoadScene(sceneName);
        }
    }

    // Load the next scene, but with player data, as well as spawning the player in the desired spawn point.
      private IEnumerator TransitionScene(GameObject player)
    {
        // Load the new scene asynchronously
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Player Spawn Point reference
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            // Move the player to the spawn point
            player.transform.position = spawnPoint.transform.position;
        }
    }
}