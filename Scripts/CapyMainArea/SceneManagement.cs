using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [Header("Scene Transition Settings")]
    public string sceneToLoad;
    public string spawnPointID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                LoadingScene.Instance.TransitionToScene(sceneToLoad, spawnPointID);
            }
            else
            {
                Debug.LogWarning("SceneTrigger: No scene specified to load.");
            }
        }
    }
}
