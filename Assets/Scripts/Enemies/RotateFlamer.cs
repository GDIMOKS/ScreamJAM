using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlamer : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x - 40, transform.eulerAngles.y - 45, transform.eulerAngles.z + 100);
    }
}
