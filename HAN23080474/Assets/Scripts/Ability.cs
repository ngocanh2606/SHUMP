using UnityEngine;

public class Ability : MonoBehaviour
{
    public PlayerController.AbilityType abilityType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.AddAbility(abilityType);
                Destroy(gameObject); // Destroy the ability object after collection
            }
        }
    }
}
