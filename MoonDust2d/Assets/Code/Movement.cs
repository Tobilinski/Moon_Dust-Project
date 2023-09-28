// Date Created: 28/08/2023
using UnityEngine;
using Cursor = UnityEngine.Cursor;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{   
    //Variables
    //////////////////////////////////////////////
    [Header("Secret Ramp")]
    [Space(10)]
    public GameObject SecretPlat;
    
    [Space(10)]
    public static bool MeleeAttackBool;
    private bool IsMoving;
    public static int KillCount;
    
    [Header("Ground Check Variables")]
    [Space(10)]
    
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    [Space(10)] 
    
    private float horizontal;
    [Header("Movement Variables")]
    [Space(10)]
    [SerializeField] private float speed = 8f; 
    [SerializeField] private float jumpForce = 12f;
    
    
    private bool isFacingRight = true;
    
    
    //physics variables
    private Rigidbody2D rb;
    
    
    //Grounded variables
    private bool triggered;
    
    //Animation variables
    [Header("Animation Slot")]
    [Space(10)]
    
    public Animator animator;
    
    //Attack variables
    [Header("Attack Weapon slot")]
    [Space(10)]
    public GameObject attackWeapon;

    private float _attackRate = 3f;
    private float _nextAttackTime;
    //Player GameObject
    [SerializeField]
    private GameObject _Player;
    //////////////////////////////////////////////




   
    public void Awake()
    { 
       Cursor.visible = false;
       rb = GetComponent<Rigidbody2D>();
       SecretPlat.SetActive(false);
    }
    // Update is called once per frame
    public void Update()
    {
        
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
                Invoke(nameof(MeleeStop), 0.1f);
                //print("Attack");
            }
        }
        else
        {
            attackWeapon.SetActive(false);
            animator.SetBool("IsKilling", false);
        }
    }

    public void MeleeStop()  
    {
        MeleeAttackBool = false;
    }


    //Test if the player is on the ground
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            triggered = true;
        }
    }
    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            triggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Benutzt ein Switch Statement !!!!!!!!!!!!!!
        if (other.gameObject.tag == "Respawn1")
        {
            _Player.transform.position = new Vector2(112.8f,12f);
        }
        if (other.gameObject.tag == "Respawn2")
        {
            _Player.transform.position = new Vector2(160.6f,12f);
        }
        if (other.gameObject.tag == "Respawn3")
        {
            _Player.transform.position = new Vector2(387.49f,27f);
        }
        if (other.gameObject.tag == "Respawn4")
        {
            _Player.transform.position = new Vector2(545.37f,29.79f);
        }
        if (other.gameObject.tag == "Respawn5")
        {
            _Player.transform.position = new Vector2(8.5f,-51.7f);
        }
        if (other.gameObject.tag == "Respawn6")
        {
            _Player.transform.position = new Vector2(46.9f,-31.7f);
        }
        if (other.gameObject.tag == "Respawn7")
        {
            _Player.transform.position = new Vector2(179.8f,-35.7f);
        }
        if (other.gameObject.tag == "Secret")
        {
            Invoke("SecretDoor", 5f);
        }
        if (other.gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(sceneBuildIndex: +1);
        }
        
    }
    
    private void SecretDoor()
    {
        SecretPlat.SetActive(true);
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
            //print("Jump");
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
