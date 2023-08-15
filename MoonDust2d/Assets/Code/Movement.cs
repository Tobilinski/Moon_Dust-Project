using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float _Speed = 7.0f;
    public float _JumpForce = 10.0f;
    private bool triggered;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            
            transform.Translate(Vector3.left * Time.deltaTime * _Speed);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _Speed);
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && triggered)
        {
            rb.velocity = Vector2.up * _JumpForce;
            print("Jump");
        }
      
        print(triggered);
        
    }

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
}
