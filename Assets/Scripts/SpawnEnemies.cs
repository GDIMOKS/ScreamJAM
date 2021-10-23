using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform spawnPoint;
    public Vector3 spawn;
    public GameObject Enemy;
    int deads = 0;
    public int count = 5;
    GameObject[] enemy;
    
    public bool enemyExist = false;
    void Start()
    {
        enemy = new GameObject[count];   
    }

    void FixedUpdate()
    {
        Quaternion quaternion = new Quaternion();
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
                enemy[i] = Instantiate<GameObject>(Enemy, spawnPoint.position + new Vector3(Random.Range(-10, 10), spawnPoint.position.y, Random.Range(-10, 10)), quaternion);
            }
        }

        deads = 0;
    }
}
