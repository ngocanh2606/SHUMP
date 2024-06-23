using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int startingLives = 3;
    //private Text livesText;
    //public GameObject gameOverPanel;
    //public UIController uiController;

    private int currentLives;

    void Start()
    {
        currentLives = PlayerPrefs.GetInt("CurrentLives", startingLives); 
        //UpdateLivesUI();
        //gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
            Debug.Log("Collide with enemy");
        }
    }

    void TakeDamage()
    {
        currentLives--;
        Debug.Log("lives:"+ currentLives);

        PlayerPrefs.SetInt("CurrentLives", currentLives);
        //UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            // Restart level immediately
            RestartLevel();
        }
    }

    //void UpdateLivesUI()
    //{
    //    livesText.text = "Lives: " + currentLives;
    //}

    void GameOver()
    {
        gameObject.SetActive(false); // Disable player object
        //// Show game over panel if UIController is assigned
        //if (uiController != null)
        //{
        //    uiController.ShowGameOverPanel();
        //}
        //else
        //{
        //    Debug.LogWarning("UIController reference not set in PlayerHealth script.");
        //}
    }

    void RestartLevel()
    {
        // Reload the current scene after a short delay
        Invoke("ReloadScene", 0.1f);
    }

    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        // Ensure PlayerPrefs are cleared if the script is destroyed
        PlayerPrefs.DeleteKey("CurrentLives");
    }
}