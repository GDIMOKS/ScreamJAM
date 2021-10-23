using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : CreatureLife
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("-25 hp");
            EditHP(-25);
        }
    }
}
