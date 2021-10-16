using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject Enemy;
    int deads = 0;
    public int count = 5;
    GameObject[] enemy;
    
    public bool enemyExist = false;
    void Start()
    {
        enemy = new GameObject[count];   
    }

    void Update()
    { 
        for (int i = 0; i < count; i++)
        {
            if (enemy[i] == null)
            {
                deads++;
            }
        }

        if (deads == count)
        {
            for (int i = 0; i < count; i++)
            {
                enemy[i] = Instantiate<GameObject>(Enemy);
                enemy[i].transform.position = spawnPoint.position + new Vector3(Random.Range(-25, 25), spawnPoint.position.y, Random.Range(-25, 25));
            }
        }

        deads = 0;
    }
}
