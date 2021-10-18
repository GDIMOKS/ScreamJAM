using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    public AudioClip MusicStart;
    public AudioClip MusicLoop;
    private AudioSource audioSource;
    public bool playerInside = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            audioSource.clip = MusicStart;
            audioSource.Play();
            playerInside = true;
        }
    }
    private void Update()
    {
        if (!audioSource.isPlaying && playerInside)
        {
            audioSource.clip = MusicLoop;
            audioSource.Play();
        }
        if (audioSource.volume > 0 && !playerInside)
        {
            audioSource.volume -= 0.5f * Time.deltaTime;
        }
        else if (audioSource.volume < 1 && playerInside)
        {
            audioSource.volume += 0.5f * Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            playerInside = false;
        }
    }
}
