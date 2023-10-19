using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
   
    public AudioSource _audioSourceWalk;
    public AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    

    public void JumpSound()
    {
        _audioSource.PlayOneShot(audioClips[0]);
    }
    public void MeleeSound()
    {
        _audioSource.PlayOneShot(audioClips[1]);
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
    }
    
    public void HealSound()
    {
        _audioSource.PlayOneShot(audioClips[3]);
    }

    public void UltimateSound()
    {
        _audioSource.PlayOneShot(audioClips[4]);
    }



}
