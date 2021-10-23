using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIAmmo : MonoBehaviour
{
    public void PrintAmmo(int _ammo, int _startAmmo)
    {
        GetComponent<Text>().text = _ammo.ToString() + "/" + _startAmmo.ToString();
    }
}
