using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum  SoundState
    {
        Silent,
        Jumping,
        Melee,
        
    }
    
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    public SoundState currentState;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SetState(currentState);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(audioClips[0]);
        SetState(SoundState.Silent);
    }
    public void MeleeSound()
    {
        _audioSource.PlayOneShot(audioClips[1]);
    }
    public void WalkSound()
    {
        _audioSource.PlayOneShot(audioClips[2]);
    }

    public void SetState(SoundState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;

            switch (currentState)
            {
                case SoundState.Jumping:
                    JumpSound();
                    break;
                case SoundState.Melee:
                    MeleeSound();
                    break;
            }
        }
    }
}
