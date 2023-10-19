using System;
using Pathfinding;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyScript : MonoBehaviour
{
    [Header("Enemy health variable")] [Space(10)]
    private float _health;
    [SerializeField]  private float _maxHealth = 30f;
    private Animator _animator;
    private AIPath _aiPath;
    public AudioClip Hit;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _aiPath = GetComponent<AIPath>();
        _animator = GetComponentInChildren<Animator>();
       _health = _maxHealth;
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
       CameraScript.Instance.ShakeCamera(4f, 0.1f);
       if(_health <= 0f)
       {
           Movement.KillCount++;
           FireBullets._UltimateAbCount++;
           //print(FireBullets._UltimateAbCount);
           Destroy(gameObject);
       }
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            _animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            _animator.SetBool("isAttacking", false);
        }
    }
}
