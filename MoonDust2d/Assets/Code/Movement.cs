// Date Created: 28/08/2023

using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
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
    public GameObject SecretDoorTimed;

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
  
    //Soul script
    private HealthManager _healthManager;

    private bool NPCDetect;
    [Header("NPC Stuff")]
    [Space(10)]
    public GameObject[] NPC;
    
    //////////////////////////////////////////////

    private Dictionary<string, Vector2> _respawnPositions = new Dictionary<string, Vector2>()
    {
        {"Respawn1", new Vector2(111.44f, 12f)},
        {"Respawn2", new Vector2(158.78f, 12f)},
        {"Respawn3", new Vector2(387.49f, 27f)},
        {"Respawn4", new Vector2(545.37f, 29.79f)},
        {"Respawn5", new Vector2(8.5f, -51.7f)},
        {"Respawn6", new Vector2(46.9f, -31.7f)},
        {"Respawn7", new Vector2(179.8f, -35.7f)},
        {"Respawn8", new Vector2(16.01f, -0.95f)},
        {"Respawn9", new Vector2(49.1f, -6.5f)},
        {"Respawn10", new Vector2(36.7f, -19f)},
        {"Respawn11", new Vector2(36.6f, -30.5f)},
        {"Respawn12", new Vector2(41.9f, -43f)},
        {"Respawn13", new Vector2(3.2f, 1f)},
        {"Respawn14", new Vector2(220.3f, -32f)},
        {"Respawn15", new Vector2(285f, -111f)},
        {"Respawn16", new Vector2(734.9f, -53f)}
    };
    


    public void Awake()
    {
        KillCount = 0;
        _soundManager = GetComponent<SoundManager>();
        _healthManager = GameObject.Find("Soul").GetComponent<HealthManager>();
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        SecretPlat.SetActive(false);
    }
    // Update is called once per frame
    public void Update()
    {
        print(KillCount);
        //////Tutorial NPC
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (NPC[0].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            else
            {
                speed = 8f;
                jumpForce = 12f;
                NPCDetect = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (NPC[0].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            else
            {
                speed = 8f;
                jumpForce = 12f;
                NPCDetect = false;
            }
            if (NPC[1].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            if (NPC[2].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (NPC[0].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            else
            {
                speed = 8f;
                jumpForce = 12f;
                NPCDetect = false;
            }

            if (NPC[1].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            if (NPC[2].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (NPC[0].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            else
            {
                speed = 8f;
                jumpForce = 12f;
                NPCDetect = false;
            }

            if (NPC[1].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            if (NPC[2].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            if (NPC[0].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            else
            {
                speed = 8f;
                jumpForce = 12f;
                NPCDetect = false;
            }

            if (NPC[1].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            if (NPC[2].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
            if (NPC[3].activeSelf)
            {
                speed= 0f;
                jumpForce = 0f;
                NPCDetect = true;
            }
        }
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
        
        if (SceneManager.GetActiveScene().name == "Level 4" && KillCount == 3)
        {
            killWalls[0].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 4" && KillCount == 7)
        {
            killWalls[1].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 4" && KillCount == 11)
        {
            killWalls[2].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 4" && KillCount == 18)
        {
            killCountDoor();
            killWalls[3].SetActive(true);
        }

      
        /////////////////////// MACH DAS CODE OBEN BESSER !!!
        
        
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
        if (MeleeAttackBool && NPCDetect == false)
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
        SecretDoorTimed.SetActive(false);
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
            _healthManager.TakeDamage(10f);
            StartCoroutine(DelayRespawn(2f));
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
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
    private IEnumerator DelayRespawn(float Time)
    {
        rb.velocity = new Vector2( 0f, 0f);
        jumpForce = 0f;
        animator.SetBool("IsKilling", false);
        animator.SetBool("IsJumping", false);
        speed= 0f;
        yield return new WaitForSeconds(Time);
        enabled = true;
        jumpForce = 12f;
        speed = 8f;
    }
}
