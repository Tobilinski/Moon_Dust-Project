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

    // Update is called once per frame
    void Update()
    {
        if (_isInteracting && _isClose && _healthManager.Health < 100f)
        {
            _healthManager.Heal(20f);
            print(_healthManager.Health);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isClose = true;
            interactText.text = "Press E to pick up";
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
    public void absorb(InputAction.CallbackContext context)
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
