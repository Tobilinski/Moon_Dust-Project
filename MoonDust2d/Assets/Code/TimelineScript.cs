using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;


public class TimelineScript : MonoBehaviour
{
    public PlayableDirector[] PD;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Tut1":
                PD[0].Play();
                break;
            case "Tut2":
                PD[1].Play();
                break;
            case "Tut3":
                PD[2].Play();
                break;
            case "Tut4":
                PD[3].Play();
                break;
            case "Tut5":
                PD[4].Play();
                break;
        }
        /*if (other.gameObject.CompareTag("Tut2"))
        {
            PD[1].Play();
        }*/
        
    }
}
