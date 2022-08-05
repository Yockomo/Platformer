using UnityEngine;
using Zenject;

public class PauseObserver : MonoBehaviour, ICanSetState<GamePauseState>
{
        private IPauseController _pauseController;
        private InputSystem _inputSystem;

        private GamePauseState _currentState;
        
        [Inject]
        private void Contsruct(IPauseController pauseController, InputSystem inputSystem)
        {
                _pauseController = pauseController;
                _inputSystem = inputSystem;
                SetState(GamePauseState.Unpause);
        }

        public void SetState(GamePauseState state)
        {
                _currentState = state;
        }
        
        private void Update()
        {
                SwitchStates();
        }

        private void SwitchStates()
        {
                if (_inputSystem.Pause && _currentState == GamePauseState.Unpause)
                {
                        SetState(GamePauseState.Pause);
                        _pauseController.SetPause();
                }

                if (!_inputSystem.Pause && _currentState == GamePauseState.Pause)
                {
                        SetState(GamePauseState.Unpause);
                        _pauseController.ResetPause();
                }
        }
}

public enum GamePauseState{ Pause, Unpause}