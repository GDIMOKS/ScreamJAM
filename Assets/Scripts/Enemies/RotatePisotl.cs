using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePisotl : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + -100, transform.eulerAngles.y + 10, transform.eulerAngles.z + 170);
    }
}
