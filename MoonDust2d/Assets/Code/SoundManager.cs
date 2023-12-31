using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
   
    public AudioSource _audioSourceWalk;
    public AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    public void JumpSound()
    {
        _audioSource.clip = audioClips[0];
        _audioSource.Play();
        _audioSource.loop = false;
    }
    public void MeleeSound()
    {
        _audioSource.clip = audioClips[1];
        _audioSource.Play();
        _audioSource.loop = false;
    }
    

    public void WalkSound()
    {
        _audioSourceWalk.clip = audioClips[2];
        _audioSourceWalk.loop = true;
        _audioSourceWalk.Play();
    }

    public void StopWalkSound()
    {
        _audioSourceWalk.Pause();
        _audioSource.loop = false;
    }
    
    public void HealSound()
    {
        _audioSource.PlayOneShot(audioClips[3]);
    }

    public void UltimateSound()
    {
        _audioSource.PlayOneShot(audioClips[4]);
    }

    public void Click()
    {
        _audioSource.PlayOneShot(audioClips[5]);
    }

    private void StopSound()
    {
        _audioSource.Stop();
    }

    public void Explosion()
    {
        _audioSource.PlayOneShot(audioClips[6]);
    }
}
