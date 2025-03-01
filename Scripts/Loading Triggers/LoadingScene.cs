
/************
Braeden Kurfman
Capstone Computing Project
Capy Quest
2/12/25
(last updated 2/28/25)
************/using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;

    [SerializeField] private GameObject playerPrefab; // GameObject reference for player prefab
    private GameObject playerInstance;

    [SerializeField] private string initialSceneName = "Level1"; // placeholder value for scenename since I update it in Unity's sidebar to allow for this script to be used multiple times
    private string targetSpawnPoint; // location of desired player spawnpoint, should be updated in case there are multiple entrances to a scene.

    void Awake()
    {
        // Singleton pattern to persist the manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Load the initial scene
            SceneManager.LoadScene(initialSceneName);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to change scenes and set spawn point
    public void TransitionToScene(string sceneName, string spawnPointID)
    {
        targetSpawnPoint = spawnPointID;
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find spawn point in the new scene
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

        foreach (var sp in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            if (sp.name == targetSpawnPoint)
            {
                spawnPoint = sp;
                break;
            }
        }

        if (spawnPoint != null) // spawns player in desired point in the scene so that the player can go through different scenes at their specific doors/ paths.
        {
            // Check if player already exists
            if (playerInstance == null)
            {
                playerInstance = GameObject.FindWithTag("Player");

                if (playerInstance == null)
                {
                    playerInstance = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
                    playerInstance.tag = "Player";
                    DontDestroyOnLoad(playerInstance);
                }
                else
                {
                    playerInstance.transform.position = spawnPoint.transform.position;
                }
            }
            else
            {
                playerInstance.transform.position = spawnPoint.transform.position;
            }
        }
        else
        {
            Debug.LogWarning("No matching SpawnPoint found in the scene.");
        }
    }
}
