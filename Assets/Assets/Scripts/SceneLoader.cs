using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour
{

    private int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void LoadNextScene()
    {

        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
