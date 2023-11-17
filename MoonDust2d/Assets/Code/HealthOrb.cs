using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class HealthOrb : MonoBehaviour
{
    public TextMeshPro interactText;
    private bool _isClose = false;
    [SerializeField]
    private HealthManager _healthManager;
    private bool _isInteracting;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isClose && _healthManager.Health < 100f)
        {
            _healthManager.Heal(30f);
            _soundManager.HealSound();
            //print(_healthManager.Health);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isClose = false;
            interactText.text = "";
        }
    }
}
