using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameManager gameManager;

    public void StartGame()
    {
        gameManager.LoadNextScene(); // Start the game from Level 1
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop playing the editor
#else
        Application.Quit(); // Quit the application in standalone builds
#endif
    }
}
