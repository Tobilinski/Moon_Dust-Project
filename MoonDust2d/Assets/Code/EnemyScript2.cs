using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{
    public float EnemyHealth2 = 30f;

    private void Update()
    {
        if(EnemyHealth2 <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
