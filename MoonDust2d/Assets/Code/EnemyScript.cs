using System;
using System.Collections;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyScript : MonoBehaviour
{
    [Header("Enemy health variable")] [Space(10)]
    private float _health;
    [SerializeField]  private float _maxHealth = 30f;
    private Animator _animator;
    private AIPath _aiPath;
    public AudioClip Hit;
    public AudioClip SoulHit;
    private AudioSource _audioSource;
    private Material _material;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _aiPath = GetComponent<AIPath>();
        _animator = GetComponentInChildren<Animator>();
        _health = _maxHealth;
        _material = GetComponentInChildren<SpriteRenderer>().material;
   }

    private void Update()
    {
       
        if(_aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else if(_aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }

    public void TakeDamage(float damageAmount)
   {
       _health -= damageAmount;
       _audioSource.PlayOneShot(Hit);
       StartCoroutine("HitMarkerdelay", 0.3f);
       CameraScript.Instance.ShakeCamera(10f, 0.2f);
       if(_health <= 0f)
       {
           //print(FireBullets._UltimateAbCount);
           Destroy(gameObject);
           Movement.KillCount++;
           FireBullets._UltimateAbCount++;
       }
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            InvokeRepeating("enemyAttackingSound",0.1f,0.48f);
            _animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            //InvokeRepeating("enemyAttackingSound",1f,0.1f);
        }
    }

    void enemyAttackingSound()
    {
        _audioSource.PlayOneShot(SoulHit);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            CancelInvoke("enemyAttackingSound");
            _animator.SetBool("isAttacking", false);
        }
    }
    private IEnumerator HitMarkerdelay(float time)
    {
        _material.color = Color.red;
        yield return new WaitForSeconds(time);
        _material.color = Color.white;
    }
}
