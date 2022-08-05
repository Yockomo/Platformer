using System;
using System.Linq;
using UnityEngine;

public abstract class ActivatedActor : Actor, IActivatedActor, IDisposable
{
    public bool IsActive { get; private set; }
    
    public Actor Activator { get; private set; }
    
    public event Action OnActivationEvent;
    public event Action OnDiactivationEvent;

    protected override void Update()
    {
        if(IsActive)
            base.Update();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            IsActive = true;
            Activator = player;
            OnActivationEvent?.Invoke();
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            IsActive = false;
            OnDiactivationEvent?.Invoke();
        }
    }

    public virtual void Dispose()
    {
        var disposable = behaviours.Select(x => x as IDisposable);
        
        foreach (var behaviour in disposable)
        {
            if (behaviour != null)
                behaviour.Dispose();
        }

        OnActivationEvent = null;
        OnDiactivationEvent = null;
    }
}

public interface IActivatedActor
{
    public bool IsActive { get; }
    public Actor Activator { get; }

    public event Action OnActivationEvent;
    public event Action OnDiactivationEvent;
}