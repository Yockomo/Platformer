using UnityEngine;

public class Player : Actor, ICanAtack
{
    private InputSystem _playerInputs;
    private CharacterController _characterController;
    
    private PlayerAnimatorManager _playersAnimatorManager;
    private PlayerAttackBehaviour _meleeAtackBehaviour;

    protected override void Init()
    {
        GetReferencesFromObject();

        if (TryGetComponent<IMoveAndRotate>(out IMoveAndRotate movable))
        {
            AddBehaviour(CreateMoveBehaviour(movable));
        }
        else
            Debug.LogError("There is no IMoveAndRotate component on  " + gameObject.name);
    }

    private void GetReferencesFromObject()
    {
        _playerInputs = GetComponent<InputSystem>();
        _characterController = GetComponent<CharacterController>();
        _playersAnimatorManager = new PlayerAnimatorManager(GetComponent<Animator>());
    }

    private PlayerStandartMoveBehaviour CreateMoveBehaviour(IMoveAndRotate movable)
    {
        return new PlayerStandartMoveBehaviour(movable, _playerInputs,
            _characterController, _playersAnimatorManager);;
    }
}
