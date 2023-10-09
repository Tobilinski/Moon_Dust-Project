using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum  SoundState
    {
        Silent,
        Jumping,
        Melee,
        Walking
    }
    
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    public SoundState currentState;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    

    public void JumpSound()
    {
        _audioSource.PlayOneShot(audioClips[0]);
        SetState(SoundState.Silent);
    }
    public void MeleeSound()
    {
        _audioSource.PlayOneShot(audioClips[1]);
        SetState(SoundState.Silent);
    }
    public void WalkSound()
    {
        _audioSource.PlayOneShot(audioClips[2]);
        SetState(SoundState.Silent);
    }

    public void SetState(SoundState newState)
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
