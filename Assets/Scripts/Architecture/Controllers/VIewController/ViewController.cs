using UnityEngine;
using Zenject;

public class ViewController : MonoBehaviour
{
    [SerializeField] private GameTimeController _timeController;
    [SerializeField] private PauseObserver _pauseController;
    
    [SerializeField] private WinLoseUI _winLoseUI;
    [SerializeField] private GameObject _pausePanel;

    private PlayerScoreComponent _playerScore;
    private PlayerHealthComponent _playerHealth;
    
    [Inject]
    private void Construct(Player player)
    {
        _playerScore = player.GetComponent<PlayerScoreComponent>();
        _playerHealth = player.GetComponent<PlayerHealthComponent>();
        
        _playerHealth.OnHpEndEvent += DrawFinalView;
        _timeController.TimeEndedEvent += DrawFinalView;
        _pauseController.OnPauseEvent += OnPausePanel;
    }

    private void OnDisable()
    {
        _playerHealth.OnHpEndEvent -= DrawFinalView;
        _timeController.TimeEndedEvent -= DrawFinalView;
        _pauseController.OnPauseEvent -= OnPausePanel;
    }

    private void DrawFinalView()
    {
        _winLoseUI.SetFinalScore(_playerScore.Score);
        _winLoseUI.SetFinalTime((int) _timeController.GetCurrentTime());
        _winLoseUI.gameObject.SetActive(true);   
    }

    private void OnPausePanel()
    {
        _pausePanel.SetActive(true);
    }
}
