using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.6f);
    }

}
