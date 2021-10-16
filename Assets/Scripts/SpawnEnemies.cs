using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject Enemy;
    public bool enemyExist = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyExist)
        {
            Enemy.transform.position = spawnPoint.position;
            Instantiate<GameObject>(Enemy);
            enemyExist = true;
        }

        if (this.Enemy.GetComponent<CreatureLife>().dead == true)
        {
            enemyExist = false;
        }
    }
}
