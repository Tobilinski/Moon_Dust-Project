using System;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
   private AudioSource audio;
   public AudioClip audioClip;
   private void Start()
   {
      audio = GetComponent<AudioSource>();
   }

   public void Play()
   {
      audio.PlayOneShot(audioClip);
      SceneManager.LoadScene("1stPoem");
   }

   public void Quit()
   {
      audio.PlayOneShot(audioClip);
      Application.Quit();
   }
}
