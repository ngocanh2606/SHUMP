using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    private int currentLevel = 0;

    public void EndGame()
    {
        // Reset player stats
        playerStats.ResetStats();

        // Load the main menu or game over scene
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to your actual main menu scene name
    }

    public void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        currentLevel++;
        if (currentLevel > 2)
        {
            EndGame();
            currentLevel = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}