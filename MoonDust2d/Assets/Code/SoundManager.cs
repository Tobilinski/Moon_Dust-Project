using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
    
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.clip = audioClips[2];
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void StopWalkSound()
    {
        _audioSource.Pause();
    }
    private void HitSound()
    {
        _audioSource.PlayOneShot(audioClips[3]);
    }




}
