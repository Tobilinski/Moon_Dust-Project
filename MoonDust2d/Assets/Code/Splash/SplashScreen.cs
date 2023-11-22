using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Content warning":
                Invoke("Splash", 4f);
                break;
            case "Scene 1":
                Invoke("Splash", 28f);
                break;
            case "Scene 2":
                Invoke("Splash", 9f);
                break;
            case "Scene 3":
                Invoke("Splash", 18f);
                break;
            case "Scene 4":
                Invoke("Splash", 13f);
                break;
            case "1stPoem":
                Invoke("Splash", 7f);
                break;
            case "2nd Poem":
                Invoke("Splash", 7f);
                break;
            case "Epilogue":
                Cursor.visible = false;
                Invoke("Splash", 65f);
                break;
            case "Credits":
               Cursor.visible = true;
                break;
        }
    }

    // Update is called once per frame
   
    private void Splash()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
