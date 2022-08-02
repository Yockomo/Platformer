using System;
using UnityEngine;

public class Player : Actor, ICanAtack
{
    private InputSystem _playerInputs;
    private CharacterController _characterController;
    private AnimationEvents _eventsPlayedOnAtackAnimation;
    
    private PlayerAnimatorManager _playersAnimatorManager;
    private PlayerComboAtackBehaviour _meleeAtackBehaviour;

    protected override void Init()
    {
        GetReferencesFromObject();

        if(TryGetComponent<ICanAtack>(out ICanAtack atacker))
        {
            _meleeAtackBehaviour = CreateComboAtackBehaviour(atacker);
            _eventsPlayedOnAtackAnimation.NextComboAtackEvent += _meleeAtackBehaviour.NextComboAtack;
            _eventsPlayedOnAtackAnimation.OffComboEvent += _meleeAtackBehaviour.OffCombo;
            _eventsPlayedOnAtackAnimation.MoveOnAtackCoroutineEvent += _meleeAtackBehaviour.MoveOnAttack;
            AddBehaviour(_meleeAtackBehaviour);
        }
        
        if (TryGetComponent<IMoveAndRotate>(out IMoveAndRotate movable))
        {
            AddBehaviour(CreateMoveBehaviour(movable));
            AddBehaviour(CreateRotateBehaviour(movable));
        }
        else
            Debug.LogError("There is no IMoveAndRotate component on  " + gameObject.name);
    }

    private void GetReferencesFromObject()
    {
        _playerInputs = GetComponent<InputSystem>();
        _characterController = GetComponent<CharacterController>();
        _eventsPlayedOnAtackAnimation = GetComponent<AnimationEvents>();
        
        _playersAnimatorManager = new PlayerAnimatorManager(GetComponent<Animator>());
    }

    private PlayerComboAtackBehaviour CreateComboAtackBehaviour(ICanAtack atacker)
    { 
        return new PlayerComboAtackBehaviour(atacker, _playerInputs, _playersAnimatorManager, _characterController);
    }
    
    private PlayerStandartMoveBehaviour CreateMoveBehaviour(IMoveAndRotate movable)
    {
        var moveBehaviour = new PlayerStandartMoveBehaviour(movable, _playerInputs,
            _characterController, _playersAnimatorManager);
        AddAtackStartEndEventsAndBehaviour(_meleeAtackBehaviour, moveBehaviour.SetAtackState,
            moveBehaviour.SetDefaultState);
        return moveBehaviour;
    }

    private PlayerStandartRotateBehaviour CreateRotateBehaviour(IMoveAndRotate movable)
    {
        var rotateBehaviour = new PlayerStandartRotateBehaviour(movable, _playerInputs);
        AddAtackStartEndEventsAndBehaviour(_meleeAtackBehaviour, rotateBehaviour.SetAtackState,
            rotateBehaviour.SetDefaultState);
        return rotateBehaviour;
    }

    private void AddAtackStartEndEventsAndBehaviour(PlayerComboAtackBehaviour _meleeAtackBehaviour,
        Action onAtackStartAction, Action onAtackEndAction)
    {
        _meleeAtackBehaviour.OnAtackEventStart += onAtackStartAction;
        _meleeAtackBehaviour.OnAtackEventEnd += onAtackEndAction;
    }
}
