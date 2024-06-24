using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameManager gameManager;
    //private Text livesText;
    //public GameObject gameOverPanel;
    //public UIController uiController;

    //private int lives =3;

    void Start()
    {
        //currentLives = PlayerPrefs.GetInt("CurrentLives", startingLives); 
        //UpdateLivesUI();
        //gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("lives before:" + playerStats.lives);
            TakeDamage();
            Debug.Log("Collide with enemy");
        }
    }

    void TakeDamage()
    {
        playerStats.lives--;
        Debug.Log("lives after:"+ playerStats.lives);

        //PlayerPrefs.SetInt("CurrentLives", currentLives);
        //UpdateLivesUI();

        if (playerStats.lives <= 0)
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

        //go to main menu
        gameManager.EndGame();
    }

    private void RestartLevel()
    {
        // Reload the current scene after a short delay
        Invoke("ReloadScene", 0.1f);
    }

    void ReloadScene()
    {
        // Reload the current scene from gameManager script
        gameManager.RestartLevel();
    }
}