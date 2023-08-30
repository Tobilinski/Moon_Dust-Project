// Date Created: 28/08/2023

using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public EnemyScript enemyScript;
   public EnemyScript2 enemyScript2;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Enemy1")
      {
         enemyScript.EnemyHealth -= 10f;
         Debug.Log(enemyScript.EnemyHealth + "Enemy Health");
         
      }
      if (other.gameObject.tag == "Enemy2")
      {
         enemyScript2.EnemyHealth2 -= 10f;
         Debug.Log(enemyScript2.EnemyHealth2 + "Enemy Health");
         
      }
   }

  
}
