using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float EnemyHealth = 30f;

    private void Update()
    {
        if(EnemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
