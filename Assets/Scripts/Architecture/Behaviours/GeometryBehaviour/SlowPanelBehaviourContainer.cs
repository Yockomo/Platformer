using System;
using UnityEngine;

public class SlowPanelBehaviourContainer : SlowBehaviourContainer
{
    [SerializeField] private float slowedMovementSpeedValue;
    
    private ISlowBehaviour _slowPanelBehaviour;
    public override ISlowBehaviour GetValue => _slowPanelBehaviour;

    protected override void Init()
    {
        if (TryGetComponent<IActivatedActor>(out var activatedActor))
        {
            _slowPanelBehaviour = new SlowPanelBehaviour(activatedActor, slowedMovementSpeedValue);
        }
    }

    private void OnDestroy()
    {
        _slowPanelBehaviour.Dispose();
    }
}

public abstract class SlowBehaviourContainer : BehaviourContainer<ISlowBehaviour> 
{
}

public interface ISlowBehaviour : IBehaviour, IDisposable
{
}