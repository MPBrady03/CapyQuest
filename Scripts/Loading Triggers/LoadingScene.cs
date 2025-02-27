using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;

    [SerializeField] private GameObject playerPrefab;
    private GameObject playerInstance;

    private string targetSpawnPoint;

    void Awake()
    {
        // Singleton pattern to persist the manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
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

        if (spawnPoint != null)
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
