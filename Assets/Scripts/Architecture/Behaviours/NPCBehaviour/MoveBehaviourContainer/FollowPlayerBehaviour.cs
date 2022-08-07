using UnityEngine;

public class FollowPlayerBehaviour : BaseBehaviour, IMoveBehaviour, ICanSetState<MoveState>
{
    private MoveState _currentState;

    private Transform _actorsTransform;
    private Transform _objectToFollow;

    private Vector3 _offset;
    
    public FollowPlayerBehaviour(Transform actorsTransform,Transform objectToFollow)
    {
        _actorsTransform = actorsTransform;
        _objectToFollow = objectToFollow;
        _offset = _actorsTransform.position - _objectToFollow.transform.position;
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
    
    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        switch (_currentState)
        {
            case (MoveState.DEFAULT):
                FollowObject();
                break;
            case (MoveState.ATACK):
                SetState(MoveState.DEFAULT);
                break;
            case (MoveState.PAUSE):
                break;
            case (MoveState.UNPAUSE):
                SetState(MoveState.DEFAULT);
                break;
        }
    }

    private void FollowObject()
    {
        _actorsTransform.transform.position = _objectToFollow.transform.position + _offset;
    }
}
