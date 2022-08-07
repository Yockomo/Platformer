using System;

public class SlowPanelBehaviour : BaseBehaviour, ISlowBehaviour, IDisposable
{
    protected IActivatedActor _parentActor;

    private ICanBeSlowed _actorMovement;
    private float _slowSpeedValue;

    public SlowPanelBehaviour(IActivatedActor parentActor, float slowSpeedValue)
    {
        _parentActor = parentActor;
        _slowSpeedValue = slowSpeedValue;

        _parentActor.OnActivationEvent += SlowDown;
    }


    public override void Pause()
    {
    }

    public override void UnPause()
    {
    }

    public override void UpdateBehaviour()
    {
    }

    private void SlowDown()
    {
        if (_actorMovement == null)
        {
            _actorMovement = _parentActor.Activator.gameObject.GetComponent<ICanBeSlowed>();
            _parentActor.OnDiactivationEvent += ResetSlowDown;
        }
        
        _actorMovement.SlowDown(_slowSpeedValue);
    }
    
    private void ResetSlowDown()
    {
        _actorMovement.ResetSpeed();
    }

    public void Dispose()
    {
        _parentActor.OnActivationEvent -= SlowDown;
        _parentActor.OnDiactivationEvent -= ResetSlowDown;
        ResetSlowDown();
    }
}
