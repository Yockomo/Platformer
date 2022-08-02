using UnityEngine;

public class PlayerStandartMoveBehaviour : MoveBehaviour<IMoveAndRotate>, ICanSetState<MoveState>
{
    private InputSystem _input;
    private CharacterController _controller;
    private PlayerAnimatorManager _animatorManager;

    private float _speed;
    private float _targetRotation;
    private float _verticalVelocity;
    private Camera _mainCamera;

    private bool Grounded = true;
    private bool isDoubleJumped;
    private float _terminalVelocity = 53.0f;
    private float _rotationVelocity;
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    private float _animationBlend;

    public PlayerStandartMoveBehaviour(IMoveAndRotate movable, InputSystem inputs,
        CharacterController controller, PlayerAnimatorManager animatorManager) : base(movable)
    {
        _input = inputs;
        _controller = controller;
        _animatorManager = animatorManager;
        _mainCamera = Camera.main;
    }

    public void SetState(MoveState state)
    {
        _currentState = state;
    }

    public void SetDefaultState()
    {
        SetState(MoveState.DEFAULT);
    }
    
    public override void Pause()
    {
        SetState(MoveState.PAUSE);
    }

    public override void UnPause()
    {
        SetState(MoveState.UNPAUSE);
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
                GroundedCheck();
                JumpAndGravity();
                Move();
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

    private void Move()
    {           
        float targetSpeed = _movable.MoveSpeed;
        if (_input.Movement == Vector2.zero) targetSpeed = 0.0f;
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = 1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * _movable.SpeedChangeRate);

            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * _movable.SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        Vector3 inputDirection = new Vector3(_input.Movement.x, 0.0f, _input.Movement.y).normalized;
        if (_input.Movement != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(_movable.Transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                _movable.RotationSmoothTime);

            _movable.Transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                         new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        _animatorManager.SetSpeedParameter(_animationBlend);
    }

    private void JumpAndGravity()
    {
        if (Grounded)
        {
            isDoubleJumped = false;

            _fallTimeoutDelta = _movable.FallTimeout;

            _animatorManager.SetJump(false);

            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }

            if (_input.Jump)
            {
                _verticalVelocity = Mathf.Sqrt(_movable.JumpHeight * -2f * _movable.Gravity);
                _animatorManager.SetJump(true);
                _input.Jump = false;
            }

            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else if (!Grounded && !isDoubleJumped && _input.Jump)
        {
            _verticalVelocity = Mathf.Sqrt(_movable.JumpHeight * -2f * _movable.Gravity);

            isDoubleJumped = true;

            _animatorManager.TriggerDoubleJump();
        }
        else
        {
            _jumpTimeoutDelta = _movable.JumpTimeout;

            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }

            _input.Jump = false;
        }

        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += _movable.Gravity * Time.deltaTime;
        }
    }

    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(_movable.Transform.position.x, _movable.Transform.position.y - _movable.GroundedOffset,
            _movable.Transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, _movable.GroundedRadius, _movable.GroundLayers,
            QueryTriggerInteraction.Ignore);

        _animatorManager.SetGrounded(Grounded);
    }
}
