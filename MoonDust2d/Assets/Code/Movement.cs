using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //physics variables
    public Rigidbody2D rb;
    public float _Speed = 7.0f;
    public float _JumpForce = 10.0f;
    
    //Grounded variables
    private bool triggered;
    
    //Animation variables
    public Animator animator;
    
    //Attack variables
    public GameObject attackWeapon;

    private float _attackRate = 2f;
    private float _nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(_nextAttackTime);
        //Movement of the player
        Move(); 
        attack();
        //Test if the player is on the ground
        //print(triggered);
        
    }
    
    //Test if the player is on the ground
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            triggered = true;
        }
    }
    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            triggered = false;
        }
    }
    //Movement of the player
    public void Move()
    {
        if(Input.GetKey(KeyCode.A)) {
            
            transform.Translate(Vector3.left * Time.deltaTime * _Speed);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Moving", true);
        }
        //Check if the Any key is pressed to change the animation back to idle
        else if (Input.GetKey(KeyCode.A) == false)
        {
            animator.SetBool("Moving", false);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _Speed);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && triggered)
        {
            rb.velocity = Vector2.up * _JumpForce;
            print("Jump");
            animator.SetBool("Moving", true);
        }
        
    }
    void attack()
    {
        if(Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _nextAttackTime = Time.time + 1f / _attackRate;
                attackWeapon.SetActive(true);
                print("Attack");
            }
            else
            {
                attackWeapon.SetActive(false);
            }
        }
    }
}
