using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanelBehaviourContainer : JumpBehaviourContainer
{
    [SerializeField] private float _jumpHeight;
    
    private IJumpBehaviour _jumpBehaviour;
    public override IJumpBehaviour GetValue => _jumpBehaviour;
    
    protected override void Init()
    {
        if (TryGetComponent<IActivatedActor>(out var activatedActor))
        {
            _jumpBehaviour = new JumpPlatformBehaviour(activatedActor, _jumpHeight);
        }
    }
}

public abstract class JumpBehaviourContainer : BehaviourContainer<IJumpBehaviour> 
{
}

public interface IJumpBehaviour : IBehaviour
{
}