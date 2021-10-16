using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : CreatureLife
{
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("-25 hp");
            EditHP(-25);
        }
    }
}
