using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChild : MonoBehaviour
{
    [SerializeField] private GameObject objectToAttach;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach.transform.parent = null;
        }
    }
}
