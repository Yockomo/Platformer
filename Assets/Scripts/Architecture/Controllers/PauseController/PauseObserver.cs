using UnityEngine;
using System;
using Zenject;

public class PauseObserver : MonoBehaviour, ICanSetState<GamePauseState>
{
        private IPauseController _pauseController;
        private InputSystem _inputSystem;

        private GamePauseState _currentState;

        public event Action OnPauseEvent;
        public event Action OnUnpauseEvent; 

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
                        PauseGame();
                }

                if (!_inputSystem.Pause && _currentState == GamePauseState.Pause)
                {
                        SetState(GamePauseState.Unpause);
                        OnUnpauseEvent?.Invoke();
                        _pauseController.ResetPause();
                }
        }

        public void PauseGame()
        {                        
                SetState(GamePauseState.Pause);
                OnPauseEvent?.Invoke();
                _pauseController.SetPause();
        }

        public void ResetPause()
        {
                _pauseController.ResetPause();
        }
}

public enum GamePauseState{ Pause, Unpause}