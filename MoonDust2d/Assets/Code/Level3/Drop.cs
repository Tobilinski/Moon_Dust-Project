using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Movement>(out Movement movementScript))
        {
           Invoke("StartAnim", 0.3f);
            //print("damage taken from melee attack");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Movement>(out Movement movementScript))
        {
            Invoke("StopAnim", 2f);
            //print("damage taken from melee attack");
        }
    }

    void StartAnim()
    {
        _animator.SetBool("Drop", true);
    }
    void StopAnim()
    {
        _animator.SetBool("Drop", false);
    }
}
