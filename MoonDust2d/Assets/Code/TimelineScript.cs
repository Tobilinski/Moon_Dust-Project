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
                PD[0].Stop();
                break;
            case "Tut3":
                PD[2].Play();
                PD[1].Stop();
                break;
            case "Tut4":
                PD[3].Play();
                PD[2].Stop();
                break;
        }
    }
}
