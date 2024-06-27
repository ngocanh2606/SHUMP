using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public enum AbilityType
    {
        IncreaseSpeed,
        DeleteEnemies,
        AddLife
    }

    [System.Serializable]
    public class Ability
    {
        public AbilityType type;
        public Sprite sprite;
    }

    public Image abilityUIImage;
    public List<Ability> abilityDefinitions = new List<Ability>();

    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private Stack<Ability> abilities = new Stack<Ability>();

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && abilities.Count > 0)
        {
            Ability ability = abilities.Pop();
            UseAbility(ability.type);
            UpdateAbilityUI();
        }
    }

    public void AddAbility(AbilityType abilityType)
    {
        Ability newAbility = abilityDefinitions.Find(a => a.type == abilityType);
        if (newAbility != null)
        {
            abilities.Push(newAbility);
            UpdateAbilityUI();
        }
    }

    void UseAbility(AbilityType abilityType)
    {
        switch (abilityType)
        {
            case AbilityType.IncreaseSpeed:
                playerMovement.AdjustSpeed(0.5f, 7f); // Example values
                break;
            case AbilityType.DeleteEnemies:
                DeleteAllEnemies();
                break;
            case AbilityType.AddLife:
                playerHealth.AddLife();
                break;
        }
    }

    void UpdateAbilityUI()
    {
        if (abilities.Count > 0)
        {
            Ability topAbility = abilities.Peek();
            abilityUIImage.sprite = topAbility.sprite;
        }
        else
        {
            abilityUIImage.sprite = null; // Clear the sprite if no abilities are left
        }
    }

    void DeleteAllEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
}
