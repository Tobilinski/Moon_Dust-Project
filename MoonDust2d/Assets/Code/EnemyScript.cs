using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
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
       CameraScript.Instance.ShakeCamera(4f, 0.1f);
       if(_health <= 0f)
       {
           FireBullets._UltimateAbCount++;
           print(FireBullets._UltimateAbCount);
           Destroy(gameObject);
       }
   }
}
