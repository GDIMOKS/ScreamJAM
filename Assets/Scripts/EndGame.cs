using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public int Keys;
    private GameObject Congrats;
    private void Start()
    {
        Congrats = GameObject.FindGameObjectWithTag("Congrat");
        Congrats.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Keys >= 5)
        {
            Congrats.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
