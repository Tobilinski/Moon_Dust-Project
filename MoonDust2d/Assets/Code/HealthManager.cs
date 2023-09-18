using Pathfinding;
using UnityEngine;
using UnityEngine.UI;

    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
public class HealthManager : MonoBehaviour
{
    [Header("Soul health Variables")]
    [Space(10)]
    public float Health = 100f;
    public Image healthBar;
    private float _attackRate = 3f;
    private float _nextAttackTime;
    
    private void Awake()
    {
        gameObject.tag = "Soul";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

   
        //Keine ahnung warum das nicht funktioniert. Es hat vorher super funktioniert.
    /*private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && Time.time >= _nextAttackTime)
        {
            TakeDamage(10f);
            _nextAttackTime = Time.time + 1f / _attackRate;
            print("damage taken");
        }
      
    }*/
    //Das hier funktioniert aber. Damage wird genommen wenn der 'Enemy' in der Box ist.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Time.time >= _nextAttackTime)
        {
            TakeDamage(10f);
            _nextAttackTime = Time.time + 1f / _attackRate;
            //print("damage taken");
        }
    }
}
