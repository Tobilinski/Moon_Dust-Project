// Date Created: 28/08/2023

using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   //public EnemyScript enemyScript;
  
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Enemy1")
      {
         //enemyScript.EnemyHealth -= 10f;
         //Debug.Log(enemyScript.EnemyHealth + "Enemy Health");
         
      }
      
     
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if(other.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyScript))
      {
         enemyScript.TakeDamage(10f);
         print("damage taken");
      }
   }
}
