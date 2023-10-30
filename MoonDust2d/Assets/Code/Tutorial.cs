using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public GameObject[] Texts;
    
    private Dictionary<string, int> TextDBase = new Dictionary<string, int>()
    {
        {"Tut1",0},
        {"Tut2",1},
        {"Tut3",2},
        {"Tut4",3}
    };
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TextDBase.TryGetValue(other.gameObject.tag, out int index))
        {
            Texts[index].SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut4"))
        {
            Invoke("UnDoor", 5f);
        }
    }

    private void UnDoor()
    {
        Texts[4].SetActive(false);
    }
    
}
