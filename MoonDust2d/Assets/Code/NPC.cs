// Date Created: 28/08/2023
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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
    public TextMeshPro interactText;
    
    private bool _isInteracting;
    private bool _nextLine;
    
    public Button theButton;
    // Update is called once per frame
    void Update()
    {
        if (_isInteracting && playerIsClose)
        {
            theButton.Select();
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                interactText.text = "";
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            } 
            _isInteracting = false;
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
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
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
            interactText.text = "Press E to interact";
            Cursor.visible = true;
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.text = "";
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
    public void TalkNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           _nextLine = true; 
        }
        else
        {
            _nextLine = false;
        }
    }
}
