//using UnityEngine;

//[CreateAssetMenu(fileName = "DeleteEnemiesAbility", menuName = "Abilities/DeleteEnemies")]
//public class DeleteEnemiesAbility : Ability
//{
//    public float duration = 3f;

//    public override void UseAbility(PlayerController playerController)
//    {
//        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
//        {
//            Destroy(enemy);
//        }
//        playerController.StartCoroutine(playerController.StopSpawningEnemies(duration));
//    }
//}