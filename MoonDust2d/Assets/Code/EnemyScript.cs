using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy health variable")] [Space(10)]
    private float _health;
    [SerializeField]  private float _maxHealth = 30f;
   

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
