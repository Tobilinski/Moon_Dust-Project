using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 movedirection;
    private float moveSpeed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    private void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movedirection * moveSpeed * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 dir)
    {
        movedirection = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
