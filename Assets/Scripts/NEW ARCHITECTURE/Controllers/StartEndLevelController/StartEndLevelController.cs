using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class StartEndLevelController : MonoBehaviour
{ 
    [SerializeField] private GameTimeController _timeController;

    private readonly string _mainMenuSceneName = "MainMenuScene";
    private readonly string _firstSceneName = "FirstScene";

    [Inject]
    private void Contsruct(Player playerInstance)
    {
        _timeController.TimeEndedEvent += LoadFirstScene;
        
        var playerHealth = playerInstance.GetComponent<PlayerHealthComponent>();
        playerHealth.OnHpEndEvent += LoadFirstScene;
    }

    private void LoadMainMenuScene()
    {
        LoadScene(_mainMenuSceneName);
    }
    
    private void LoadFirstScene()
    {
        LoadScene(_firstSceneName);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}