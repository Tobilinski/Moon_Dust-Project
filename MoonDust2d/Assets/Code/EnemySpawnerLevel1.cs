using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLevel1 : MonoBehaviour
{
    private float SpawnSpeed = 0.5f;
    [Header("Wave one")]
    [Space(10)]
    public GameObject[] EnemyWave1;
    
    [Header("Wave two")]
    [Space(10)]
    public GameObject[] EnemyWave2;
    
    [Header("Wave three")]
    [Space(10)]
    public GameObject[] EnemyWave3;
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawner1")
        {
            StartCoroutine(Spawning1());
        }
        if (other.gameObject.tag == "Spawner2")
        {
            StartCoroutine(Spawning2());
        }
        if (other.gameObject.tag == "Spawner3")
        {
            StartCoroutine(Spawning3());
        }
    }

    
    IEnumerator Spawning1()
    {
        foreach (var number in EnemyWave1)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
    IEnumerator Spawning2()
    {
        foreach (var number in EnemyWave2)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
    IEnumerator Spawning3()
    {
        foreach (var number in EnemyWave3)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
}
