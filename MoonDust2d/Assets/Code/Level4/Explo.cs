using UnityEngine;

public class Explo : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float ExploForce = 2500f;
    //Sound script variable
    private SoundManager _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _soundManager = GetComponent<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Explo"))
        {
            _soundManager.Explosion();
            _rb.velocity = new Vector2(0, ExploForce) * Time.deltaTime;
        }
    }
}
