using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndLevelController : MonoBehaviour
{
    private readonly string _mainMenuSceneName = "MainMenuScene";
    private readonly string _firstSceneName = "FirstScene";

    public void LoadMainMenuScene()
    {
        LoadScene(_mainMenuSceneName);
    }

    public void LoadFirstScene()
    {
        LoadScene(_firstSceneName);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}