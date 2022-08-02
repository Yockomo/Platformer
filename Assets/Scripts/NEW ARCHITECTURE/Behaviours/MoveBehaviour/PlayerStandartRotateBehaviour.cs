using UnityEngine;

public class PlayerStandartRotateBehaviour : MoveBehaviour<IMoveAndRotate>, ICanSetState<MoveState>
{
    private InputSystem _input;
    private Camera _mainCamera;

    private float _targetRotation;
    private float _rotationVelocity;

    public PlayerStandartRotateBehaviour(IMoveAndRotate movable, InputSystem inputs ) : base(movable)
    {
        _input = inputs;
        _mainCamera = Camera.main;
    }

    public void SetState(MoveState state)
    {
        _currentState = state;
    }
    
    public override void Pause()
    {
        SetState(MoveState.PAUSE);
    }

    public override void UnPause()
    {
        SetState(MoveState.UNPAUSE);
    }

    public void SetDefaultState()
    {
        SetState(MoveState.DEFAULT);
    }
    
    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        switch (_currentState)
        {
            case MoveState.DEFAULT:
                Rotate();
                break;
            case MoveState.ATACK:
                break;
            case MoveState.PAUSE:
                break;
            case MoveState.UNPAUSE:
                SetDefaultState();
                break;
        }
    }

    private void Rotate()
    {
        if (_input.Movement != Vector2.zero)
        {
            Vector3 inputDirection = new Vector3(_input.Movement.x, 0.0f, _input.Movement.y).normalized;
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(_movable.Transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                _movable.RotationSmoothTime);
            Debug.Log(rotation);
            _movable.Transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }
}
