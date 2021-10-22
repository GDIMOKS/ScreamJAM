using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInChildren : MonoBehaviour
{
    public void Death()
    {
        GetComponentInParent<CreatureLife>().Delete();
    }
}
