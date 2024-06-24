using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int lives = 3;
    public int score;
    public int level;

    public void ResetStats()
    {
        // Reset stats to default values if needed
        lives = 3;
        score = 0;
        level = 1;
    }
}