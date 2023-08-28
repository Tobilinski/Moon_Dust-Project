// Date Created: 28/08/2023
using UnityEngine;

public class Weapon : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Enemy")
      {
         Destroy(other.gameObject);
      }
   }
}
