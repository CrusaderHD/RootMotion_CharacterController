using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //BeginTraining is a function that will load the training scene.
    public void PlayGame()
    {
        //Load Scene
        //TODO: Update the scene/Build Index to ensure proper scenes are used and loaded.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //ExitTraining will exit the user out of the training module.
    public void QuitGame()
    {
        //Since this wont happen within the Unity Editor. Adding a Debug Log method.
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
}
