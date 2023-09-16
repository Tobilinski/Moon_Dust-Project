using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Soul health Variables")]
    [Space(10)]
    public float Health = 100f;
    public Image healthBar;
    private float _attackRate = 3f;
    private float _nextAttackTime;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(10f);
        }
        
            
    }
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthBar.fillAmount = Health / 100f;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void Heal(float heal)
    {
        Health += heal;
        healthBar.fillAmount = Health / 100f;
    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Time.time >= _nextAttackTime)
        {
            TakeDamage(10f);
            _nextAttackTime = Time.time + 1f / _attackRate;
            print("damage taken");
        }
      
    }
}
