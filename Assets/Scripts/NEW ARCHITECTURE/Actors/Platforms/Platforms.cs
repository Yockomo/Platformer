using System;
using System.Linq;
using UnityEngine;

public class Platforms : Actor, IActivatedActor, IDisposable
{
    public bool IsActive { get; private set; }
    
    public Actor Activator { get; private set; }
    
    public event Action OnActivationEvent;
    public event Action OnDiactivationEvent;

    protected override void Init()
    {
    }

    protected override void Update()
    {
        if(IsActive)
            base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            IsActive = true;
            Activator = player;
            OnActivationEvent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            IsActive = false;
            OnDiactivationEvent?.Invoke();
        }
    }

    public void Dispose()
    {
        var disposable = behaviours.Select(x => x as IDisposable);
        
        foreach (var behaviour in disposable)
        {
            if (behaviour != null)
                behaviour.Dispose();
        }
    }
}

public interface IActivatedActor
{
    public bool IsActive { get; }
    public Actor Activator { get; }

    public event Action OnActivationEvent;
    public event Action OnDiactivationEvent;
}
