// Date Created: 28/08/2023

using System;
using UnityEngine;
using Pathfinding;

public class Weapon : MonoBehaviour
{
   //public EnemyScript enemyScript;
   public AIPath[] _AIPath;
   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyScript))
       {
           enemyScript.TakeDamage(10f);
           print("damage taken");
       }
       if(other.gameObject.CompareTag("SlowDown"))
       {
           slowBabaSlow();
           Destroy(other.gameObject);
       }
   }
   void FastAgainBaba()
   {
       _AIPath[0].maxSpeed = 1.5f;
       _AIPath[1].maxSpeed = 1.5f;
       
   }
   void slowBabaSlow()
   {
       _AIPath[0].maxSpeed = 0.5f;
       _AIPath[1].maxSpeed = 0.5f;
       Invoke("FastAgainBaba",4f);
   }
}
