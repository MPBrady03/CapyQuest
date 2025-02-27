/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/28/24
******************/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public string sceneName;      // Name of the scene to load
    public Button transitionButton; // Reference to the UI Button component

    void Start()
    {
        if (transitionButton != null)
        {
            transitionButton.onClick.AddListener(OnButtonPressed); // calls the button to do its action
        }
        else
        {
            Debug.LogWarning("Transition Button is not assigned.");
        }
    }

    // When button is pressed, go to main scene
    private void OnButtonPressed()
    {
        SceneManager.LoadScene(sceneName); // after play is clicked, open the game.
    }
}