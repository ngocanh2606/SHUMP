using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameManager gameManager;
    public TextMeshProUGUI lifeText;

    void Start()
    {
        UpdateLifeText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("lives before:" + playerStats.lives);
            TakeDamage();
            Debug.Log("Collide with enemy");
        }
    }

    void TakeDamage()
    {
        playerStats.lives--;

        if (playerStats.lives <= 0)
        {
            GameOver();
        }
        else
        {
            // Restart level immediately
            RestartLevel();
        }

        UpdateLifeText();
    }

    public void AddLife()
    {
        playerStats.lives++;
        UpdateLifeText();
    }

    void UpdateLifeText()
    {
        lifeText.text = "Lives: " + playerStats.lives;
    }

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