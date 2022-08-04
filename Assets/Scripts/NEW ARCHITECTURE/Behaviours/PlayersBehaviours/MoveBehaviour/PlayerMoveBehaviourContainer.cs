using UnityEngine;

public class PlayerMoveBehaviourContainer : MoveBehaviourContainer, ICanBeSlowed
{
    [SerializeField] private PlayersMovableConfig _movableConfig;
    
    private MoveBehaviour<IMoveAndRotate> _playerStandartMoveBehaviour;
    public override IMoveBehaviour GetValue => _playerStandartMoveBehaviour;

    private float _defaultMoveSpeedValue;
    
    protected override void Init()
    {
        _defaultMoveSpeedValue = _movableConfig.MoveSpeed;
        var playersAnimatorManager = GetComponent<IHaveAnimatorManager<PlayerAnimatorManager>>().GetAnimatorManager();
        
        _playerStandartMoveBehaviour = new PlayerStandartMoveBehaviour(_movableConfig, GetComponent<InputSystem>(),
            GetComponent<CharacterController>(), transform, playersAnimatorManager);
    }

    public void SlowDown(float newSpeedValue)
    {
        _movableConfig.SetMoveSpeed(newSpeedValue);
    }

    public void ResetSpeed()
    {
        _movableConfig.SetMoveSpeed(_defaultMoveSpeedValue);
    }
}

public interface ICanBeSlowed
{
    void SlowDown(float newSpeedValue);
    void ResetSpeed();
}
