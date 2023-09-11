// Date Created: 28/08/2023
using UnityEngine;
using Cursor = UnityEngine.Cursor;
using Pathfinding;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    
    private  bool MeleeAttackBool;
    private bool IsMoving;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float horizontal;
    private float speed = 8f;
    private float jumpForce = 10f;
    private bool isFacingRight = true;
    
    
    //physics variables
    public Rigidbody2D rb;
    public float _Speed = 24f;
    public float _JumpForce = 80.0f;
    
    //Grounded variables
    private bool triggered;
    
    //Animation variables
    public Animator animator;
    
    //Attack variables
    public GameObject attackWeapon;

    private float _attackRate = 3f;
    private float _nextAttackTime;

    // Update is called once per frame
    void Update()
    {
        //print(_nextAttackTime);
        //Movement of the player
        Move(); 
        
        
        //attack();
        
        
        //Test if the player is on the ground
        //print(triggered);
        
        //Change the animation to jumping
        if (triggered)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (IsMoving)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
       
        
        
        if (MeleeAttackBool)
        {
            if(Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + 1f / _attackRate;
                attackWeapon.SetActive(true);
                animator.SetBool("IsKilling", true);
                //print("Attack");
            }
            
            
        }
        else
        {
            attackWeapon.SetActive(false);
            animator.SetBool("IsKilling", false);
        }
        
     
    }

    
    
    
    
    
    
    
    
    private void Start()
    {
        Cursor.visible = false;
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
            
            //transform.Translate(Vector3.left * Time.deltaTime * _Speed);
            //transform.localScale = new Vector3(-1, 1, 1);
            //Change the animation to moving
            animator.SetBool("Moving", true);
            animator.SetBool("IsJumping", false);
        }
        //Check if the Any key is pressed to change the animation back to idle
        else if (Input.GetKey(KeyCode.A) == false)
        {
            //Change the animation to idle
            animator.SetBool("Moving", false);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.right * Time.deltaTime * _Speed);
            //transform.localScale = new Vector3(1, 1, 1);
            //Change the animation to moving
            animator.SetBool("Moving", true);
            animator.SetBool("IsJumping", false);
        }
    }
    //Attack of the player
    void attack()
    {
        if(Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _nextAttackTime = Time.time + 1f / _attackRate;
                attackWeapon.SetActive(true);
                //print("Attack");
            }
            else
            {
                attackWeapon.SetActive(false);
            }
        }
        //Change the animation to attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("IsKilling", true);
        }
        else
        {
            animator.SetBool("IsKilling", false);  
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
       Vector3 localScale = transform.localScale;
       localScale.x *= -1;
       transform.localScale = localScale;
    }
    
    public void MoveNew(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if (context.performed)
        {
            IsMoving = true;
        }
        else if (context.canceled)
        {
            IsMoving = false;
        }
        
        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.y,jumpForce);
            print("Jump");
        }

        if (context.canceled && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.1f);
            //print("Jump");
        }
       
    }
    public void AttackMelee(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MeleeAttackBool = true;
            //print("Attack");
        }
        else if (context.canceled)
        {
            MeleeAttackBool = false;
        }
    }
    
}
