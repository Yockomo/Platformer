using UnityEngine;

public class PlayerMoveBehaviourContainer : MoveBehaviourContainer
{
    [SerializeField] private PlayersMovableConfig _movableConfig;

    private MoveBehaviour<IMoveAndRotate> _playerStandartMoveBehaviour;
    public override IMoveBehaviour GetValue => _playerStandartMoveBehaviour;

    protected override void Init()
    {
        var playersAnimatorManager = GetComponent<IHaveAnimatorManager<PlayerAnimatorManager>>().AnimatorManager;
        
        _playerStandartMoveBehaviour = new PlayerStandartMoveBehaviour(_movableConfig, GetComponent<InputSystem>(),
            GetComponent<CharacterController>(), transform, playersAnimatorManager);
    }
}
