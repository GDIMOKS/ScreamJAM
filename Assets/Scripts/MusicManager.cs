using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private BattleMusic battleMusic;
    public AudioSource ambient;
    private void Start()
    {
        battleMusic = GetComponentInChildren<BattleMusic>();
    }
    private void Update()
    {
        if (battleMusic.playerInside && ambient.volume > 0)
        {
            ambient.volume -= 0.5f * Time.deltaTime;
        }
        else if (!battleMusic.playerInside && ambient.volume < 1)
        {
            ambient.volume += 0.5f * Time.deltaTime;
        }
    }
}
