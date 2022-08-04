using UnityEngine;
using Zenject;

public class JumpPlatformBehaviour : BaseBehaviour, IJumpBehaviour, ICanSetState<ActiveState>
{
    protected ActiveState _currentState;
    
    protected IActivatedActor _parentActor;
    private CharacterController _playersController;

    private float _jumpHeight;
    private float _jumpOffset = 10;
    public JumpPlatformBehaviour(IActivatedActor parentActor, float jumpHeight)
    {
        _parentActor = parentActor;
        _jumpHeight = jumpHeight;
    }
    
    public void SetState(ActiveState state)
    {
        _currentState = state;
    }

    public override void Pause()
    {
       SetState(ActiveState.PAUSE);
    }

    public override void UnPause()
    {
        SetState(ActiveState.UNPAUSE);
    }
    
    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        switch (_currentState)
        {
            case ActiveState.DEFAULT:
                WaitForActivation();
                break;            
            case ActiveState.PAUSE:
                break;            
            case ActiveState.UNPAUSE:
                SetState(ActiveState.DEFAULT);
                break;
        }
    }

    private void WaitForActivation()
    {
        if (_playersController == null)
        {
            _playersController = _parentActor.Activator.gameObject.GetComponent<CharacterController>();
        }

        _playersController.Move(Vector3.up * Time.deltaTime * (_jumpOffset * _jumpHeight) );
    }
}

public enum ActiveState { DEFAULT,PAUSE,UNPAUSE }
