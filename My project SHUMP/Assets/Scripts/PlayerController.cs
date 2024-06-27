//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    private Stack<Ability> abilities = new Stack<Ability>();

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && abilities.Count > 0)
//        {
//            Ability ability = abilities.Pop();
//            ability.UseAbility(this);
//        }
//    }

//    public void AddAbility(Ability ability)
//    {
//        abilities.Push(ability);
//    }

//    public IEnumerator IncreaseSpeed(float amount, float duration)
//    {
//        moveSpeed += amount;
//        yield return new WaitForSeconds(duration);
//        moveSpeed -= amount;
//    }

//    public IEnumerator StopSpawningEnemies(float duration)
//    {
//        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
//        foreach (var spawner in spawners)
//        {
//            spawner.CanSpawn = false;
//        }
//        yield return new WaitForSeconds(duration);
//        foreach (var spawner in spawners)
//        {
//            spawner.CanSpawn = true;
//        }
//    }
//}
