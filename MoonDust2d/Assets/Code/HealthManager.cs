using System.Collections;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
public class HealthManager : MonoBehaviour
{
    [Header("Soul health Variables")] [Space(10)]
    public AIPath aipath;
    [Header("Soul health Variables")]
    [Space(10)]
    public float Health = 100f;
    public Image healthBar;
    [SerializeField]
    private float _attackRate = 3f;
    private float _nextAttackTime;
    [Header("Hit Marker")]
    [Space(10)]
    //Hitmarker
    public GameObject hitMarker;
    // Health marker
    public GameObject VignetteHealth;
    
    private void Awake()
    {
        gameObject.tag = "Soul";
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            TakeDamage(10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(10f);
        }
        if(aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(aipath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }

        if (Health > 100)
        {
            Health = 100;
        }
    }
    
    
    public void TakeDamage(float damage)
    {
        StartCoroutine("HitMarkerdelay", 0.1f);
        Health -= damage;
        healthBar.fillAmount = Health / 100f;
        if (Health <= 0)
        {
            FireBullets._UltimateAbCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void Heal(float heal)
    {
        Health += heal;
        healthBar.fillAmount = Health / 100f;
        StartCoroutine("HVignette", 0.15f);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Time.time >= _nextAttackTime)
        {
            TakeDamage(10f);
            _nextAttackTime = Time.time + 1f / _attackRate;
            //print("damage taken");
        }
    }

    private IEnumerator HitMarkerdelay(float time)
    {
        hitMarker.SetActive(true);
        yield return new WaitForSeconds(time);
        hitMarker.SetActive(false);
    }
    private IEnumerator HVignette(float time)
    {
        VignetteHealth.SetActive(true);
        yield return new WaitForSeconds(time);
        VignetteHealth.SetActive(false);
    }
}
