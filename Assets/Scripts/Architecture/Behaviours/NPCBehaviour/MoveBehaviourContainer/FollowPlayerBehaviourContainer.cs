using UnityEngine;

public class FollowPlayerBehaviourContainer : MoveBehaviourContainer
{
    [SerializeField] private Transform _objectToFollow;
    
    private IMoveBehaviour _moveBehaviour;
    public override IMoveBehaviour GetValue => _moveBehaviour;
    protected override void Init()
    {
        _moveBehaviour = new FollowPlayerBehaviour(transform, _objectToFollow);
    }
}
