// Date Created: 28/08/2023

using System.Collections.Generic;
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
    public GameObject[] killWalls;
    public GameObject Endwall;

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
    
    
    private bool _isFacingRight = true;
    
    
    //physics variables
    private Rigidbody2D rb;
    private bool _isJumping;
    
    //Grounded variables
    private bool _triggered;
    
    //Animation variables
    [Header("Animation Slot")]
    [Space(10)]
    //player animator
    public Animator animator;
    [Header("Elevator")]
    [Space(10)]
    public Animator animatorElevator1;
    public Animator animatorElevator2;
    
    //Attack variables
    [Header("Attack Weapon slot")]
    [Space(10)]
    public GameObject attackWeapon;

    private float _attackRate = 3f;
    private float _nextAttackTime;
     //Sound script variable
    private SoundManager _soundManager;
  
   
    //////////////////////////////////////////////

    private Dictionary<string, Vector2> _respawnPositions = new Dictionary<string, Vector2>()
    {
        {"Respawn1", new Vector2(112.8f, 12f)},
        {"Respawn2", new Vector2(160.6f, 12f)},
        {"Respawn3", new Vector2(387.49f, 27f)},
        {"Respawn4", new Vector2(545.37f, 29.79f)},
        {"Respawn5", new Vector2(8.5f, -51.7f)},
        {"Respawn6", new Vector2(46.9f, -31.7f)},
        {"Respawn7", new Vector2(179.8f, -35.7f)},
        {"Respawn8", new Vector2(16.01f, -0.95f)},
        {"Respawn9", new Vector2(49.1f, -6.5f)},
        {"Respawn10", new Vector2(36.7f, -19f)},
        {"Respawn11", new Vector2(36.6f, -30.5f)},
        {"Respawn12", new Vector2(41.9f, -43f)}
        
    };
    


    public void Awake()
    {
        KillCount = 0;
        _soundManager = GetComponent<SoundManager>();
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        SecretPlat.SetActive(false);
    }
    // Update is called once per frame
    public void Update()
    {
        // checks kill counts and does something depending on which level you are on
        if (SceneManager.GetActiveScene().name == "Level 1" && KillCount == 14)
        {
            killCountDoor();
        }
        if (SceneManager.GetActiveScene().name == "Level 2" && KillCount == 20)
        {
            killCountDoor();
        }
       
        if (SceneManager.GetActiveScene().name == "Level 3" && KillCount == 11)
        {
            killWalls[0].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 3" && KillCount == 14)
        {
            killWalls[1].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 3" && KillCount == 18)
        {
            killWalls[2].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 3" && KillCount == 22)
        {
            killCountDoor();
        }


        
        
        //Test if the player is on the ground
        //print(triggered);
        
        //Change the animation to jumping
        if (_triggered)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        //Makes the player Mover Lol
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (!_isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (_isFacingRight && horizontal < 0f)
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
       
        
        //melée attack
        if (MeleeAttackBool)
        {
            
            if(Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + 1f / _attackRate;
                //melee sound goes here
                _soundManager.MeleeSound();
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
    private void killCountDoor()
    {
        Endwall.SetActive(false);
    }

    private void SectioningDoor1()
    {
        killWalls[0].SetActive(false);
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
            _triggered = true;
        }
    }
    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _triggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_respawnPositions.TryGetValue(other.gameObject.tag, out Vector2 newPosition))
        {
            transform.position = newPosition;
        }
        
        switch (other.gameObject.tag)
        {
            case "Secret":
                Invoke("SecretDoor", 5f);
                break;
            case "NextLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "ElevatorUp":
                animatorElevator2.SetTrigger("IsUppieUp");
                break;
            case "ElevatorDown":
                animatorElevator1.SetTrigger("IsDown");
                break;
            case "Section":
                Invoke("SectioningDoor1", 11f);
                break;
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
        _isFacingRight = !_isFacingRight;
       Vector3 localScale = transform.localScale;
       localScale.x *= -1;
       transform.localScale = localScale;
    }
    
    public void MoveNew(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if (context.performed)
        {
            _soundManager.WalkSound();
            IsMoving = true;
        }
        else if (context.canceled)
        {
            _soundManager.StopWalkSound();
            IsMoving = false;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _isJumping =true;
            rb.velocity = new Vector2(rb.velocity.y,jumpForce);
           _soundManager.JumpSound();
            //print("Jump");
        }
        

        if (context.canceled && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.1f);
            //print("Jump");
            _isJumping = false;
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
