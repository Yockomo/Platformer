using System;

public class PlayerAttackBehaviour : AtackBehaviour<ICanAttack>, ICanSetState<AtackStates>
{
    private InputSystem _input;
    private PlayerAnimatorManager _animatorManager;

    public event Action OnAtackEventStart;

    public PlayerAttackBehaviour(ICanAttack attacker,
        InputSystem inputs, PlayerAnimatorManager animatorManager) : base(attacker)
    {
        _input = inputs;
        _animatorManager = animatorManager;
    }

    public void SetState(AtackStates state)
    {
        _currentState = state;
    }
        
    public override void Pause()
    {
        SetState(AtackStates.PAUSE);
    }

    public override void UnPause()
    {
        SetState(AtackStates.UNPAUSE);
    }

    public override void UpdateBehaviour()
    {
        HandleCurrentState();   
    }
        
    void HandleCurrentState()
    {
        switch (_currentState)
        {
            case AtackStates.ATACK:
                HandleFirstAtack();
                break;
            case AtackStates.PAUSE:
                break;
            case AtackStates.UNPAUSE:
                SetState(AtackStates.ATACK);
                break;
        }
    }

    private void HandleFirstAtack()
    {
        if (PlayerAtack())
        {
            OnAtackEventStart?.Invoke();
            _animatorManager.SetAtack();
        }
    }
        
    private bool PlayerAtack()
    {
        return _input.Atack && _animatorManager.IsGrounded();
    }
}