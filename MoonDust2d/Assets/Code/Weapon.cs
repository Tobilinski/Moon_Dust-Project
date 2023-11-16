// Date Created: 28/08/2023
using UnityEngine;
using Pathfinding;

public class Weapon : MonoBehaviour
{
    [Header("Amount of enemies for slow ability")]
    [Space(10)]
    public AIPath[] _AIPath;
   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyScript))
       {
           enemyScript.TakeDamage(10f);
           //print("damage taken from melee attack");
       }
   }
}
