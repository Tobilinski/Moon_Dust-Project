using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play()
   {
      SceneManager.LoadScene("1stPoem");
   }

   public void Quit()
   {
      Application.Quit();
   }
}
