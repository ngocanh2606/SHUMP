using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60f;
    private float timeRemaining;
    private bool timerRunning = true;

    public Image countdownBar;

    public GameObject winUI; // Reference to the Win UI GameObject
    public float timeToNextLevel = 5f; // Time to wait before loading the next level
    public GameManager gameManager;

    void Start()
    {
        timeRemaining = totalTime;
        UpdateUI();
        winUI.SetActive(false); // Ensure Win UI is initially hidden
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;
                StopSpawningEnemies();
                UpdateUI();
            }
        }
        if (!timerRunning && AreAllEnemiesDead())
        {
            ShowWinUI();
        }
    }

    void UpdateUI()
    {
        countdownBar.fillAmount = timeRemaining / totalTime;
    }

    void StopSpawningEnemies()
    {
        // Implement logic to stop enemy spawning
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    bool AreAllEnemiesDead()
    {
        // Implement logic to check if all enemies are dead
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    void ShowWinUI()
    {
        winUI.SetActive(true);
        Invoke("LoadNextLevel", timeToNextLevel); // Load next level after a delay
    }

    void LoadNextLevel()
    {
        gameManager.LoadNextScene(); // Call Game Manager to load the next scene
    }
}