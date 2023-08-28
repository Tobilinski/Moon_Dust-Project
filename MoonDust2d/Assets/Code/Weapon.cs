// Date Created: 28/08/2023

using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public EnemyScript enemyScript;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Enemy")
      {
         enemyScript.EnemyHealth -= 10f;
         Debug.Log(enemyScript.EnemyHealth + "Enemy Health");
         
      }
   }

  
}
