using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] audioClips;

    public void Update()
    {
        
    }

    public void PlaySound(int soundID)
    {
        _audioSource.clip = audioClips[soundID];
        _audioSource.Play();
    }

    public void PlaySound(AudioClip sound)
    {
        _audioSource.clip = sound;
        _audioSource.Play();
    }
    
    /* File sound indexes(?) !!!!!!!!!!!!!
        0 = open doors
        1 = Unlock doors
        2 = Vent crawling sounds 
        3 = Locker
        
     */
}
