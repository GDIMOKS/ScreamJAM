using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    private CameraMovement cam;
    private void Start()
    {
        PauseMenu.SetActive(false);
        cam = GetComponentInParent<CameraMovement>();
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (PauseMenu.activeSelf)
            {
                Cont();
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                cam.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void Cont()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;

        cam.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
