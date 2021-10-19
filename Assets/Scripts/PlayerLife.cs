using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : CreatureLife
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("-25 hp");
            EditHP(-25);
        }
    }
}
