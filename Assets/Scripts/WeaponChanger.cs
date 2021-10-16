using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject shotGun;
    public GameObject pistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            shotGun.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            shotGun.SetActive(true);
        }
    }
}
