using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explo : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float ExploForce = 2500f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Explo"))
        {
            //_rb.AddForce(new Vector2(0, ExploForce) * Time.deltaTime, ForceMode2D.Impulse);  
            _rb.velocity = new Vector2(0, ExploForce) * Time.deltaTime;
        }
    }
}
