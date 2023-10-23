using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletAmount;
    [SerializeField]
    private float startAngle, endAngle;
    
    private Vector2 bulletMoveDirection;
    
    public static int _UltimateAbCount = 0;
    public bool UltimateAttackBool;
    public Image CorruptionMeter;
    private SoundManager _soundManager;
    private ParticleSystem particleSystem;
    private void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            
            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            
            angle += angleStep;
        }
        _soundManager.UltimateSound();
    }

    private void Update()
    {
        UltimateAttack();
        CorruptionMeter.fillAmount = _UltimateAbCount / 4f;
        if (_UltimateAbCount >= 4)
        {
            particleSystem.Play();
        }
        else
        {
            particleSystem.Stop();
        }
    }

    public void UltimateAttack()
    {
        
        if (UltimateAttackBool && Movement.MeleeAttackBool && _UltimateAbCount >= 4)
        {
            //print("Ultimate Attack"); 
            Fire();
            _UltimateAbCount = 0;
            
        }
       
    }
    
    public void Ultimate(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UltimateAttackBool = true;
            //print("UltimateAttack");
        }
        else if (context.canceled)
        {
            UltimateAttackBool = false;
        }
    }
}
