using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float _health, _maxHealth = 30f;
   

   private void Start()
   {
       _health = _maxHealth;
   }

   public void TakeDamage(float damageAmount)
   {
       _health -= damageAmount;
       if(_health <= 0f)
       {
           Destroy(gameObject);
       }
   }
}
