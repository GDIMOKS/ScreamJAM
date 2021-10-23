using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private BattleMusic[] battleMusic;
    public AudioSource ambient;
    int count;
    private void Start()
    {        
        battleMusic = GetComponentsInChildren<BattleMusic>();
        count = battleMusic.Length;
    }
    private void Update()
    {
        for (int i = 0; i < battleMusic.Length; i++)
        {
            if (battleMusic[i].playerInside && ambient.volume > 0)
            {
                ambient.volume -= 0.5f * Time.deltaTime;
            }
            else if (!battleMusic[i].playerInside && ambient.volume < 1)
            {
                count++;
                //ambient.volume += 0.5f * Time.deltaTime;
            }
        }
        //Debug.Log(count);
        if (count == battleMusic.Length)
        {
            ambient.volume += 0.5f * Time.deltaTime;
        }
        count = 0;

        
    }
}
