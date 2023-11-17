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
    
    [Header("Wave four")]
    [Space(10)]
    public GameObject[] EnemyWave4;
    
    [Header("Wave Five")]
    [Space(10)]
    public GameObject[] EnemyWave5;
    [Header("Wave Five")]
    [Space(10)]
    public GameObject[] EnemyWave6;
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Spawner1":
                StartCoroutine(Spawning1());
                break;
            case "Spawner2":
                StartCoroutine(Spawning2());
                break;
            case "Spawner3":
                StartCoroutine(Spawning3());
                break;
            case "Spawner4":
                StartCoroutine(Spawning4());
                break;
            case "Spawner5":
                StartCoroutine(Spawning5());
                break;
            case "Spawner6":
                StartCoroutine(Spawning6());
                break;
            case "Spawner7":
                StartCoroutine(Spawning7());
                break;
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
    IEnumerator Spawning4()
    {
        yield return new WaitForSeconds(2f);
        foreach (var number in EnemyWave3)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
    IEnumerator Spawning5()
    {
        foreach (var number in EnemyWave4)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
    IEnumerator Spawning6()
    {
        foreach (var number in EnemyWave5)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
    IEnumerator Spawning7()
    {
        foreach (var number in EnemyWave6)
        {
            number.SetActive(true);
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }
}
