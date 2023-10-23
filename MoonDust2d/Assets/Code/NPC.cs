// Date Created: 28/08/2023

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class NPC : MonoBehaviour
{
    [Header("Dialogue Variables")]
    [Space(10)]
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    [Space(10)]
    private int index;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    [Space(10)]
    

    public GameObject Arrow;
    private bool _isInteracting;
    private bool _nextLine;
    //Audio source
    private AudioSource _audiosource;
    public Button theButton;
    
    // Update is called once per frame
    void Update()
    {
        _audiosource = GetComponent<AudioSource>();
        if (_isInteracting && playerIsClose)
        {
            _isInteracting = false;
            theButton.Select();
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else if (dialogueText.text == "")
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        

        

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
        else
        {
            contButton.SetActive(false);
        }

        if (_nextLine)
        {
            contButton.SetActive(false);
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
            }
            _nextLine = false;
        }
    }
    

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        
        foreach (char letter in dialogue[index])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            if (!dialoguePanel.activeInHierarchy)
            {
                break;
            }
        }
    }
    
    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _audiosource.Play();
            Arrow.SetActive(true);
            Cursor.visible = true;
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Arrow.SetActive(false);
            Cursor.visible = false;
            playerIsClose = false;
            zeroText();
        }
    }
    
    public void Talk(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            
            _isInteracting = true;
            //print("Interact");
        }
        else if (context.canceled)
        {
            _isInteracting = false;
        }
    }
    
}
