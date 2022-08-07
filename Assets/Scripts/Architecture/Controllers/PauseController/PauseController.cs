using System.Collections.Generic;
using UnityEngine;

public class PauseController : IPauseController
{
    private List<IActor> _actorsToPause = new List<IActor>(10);

    public List<IActor> ActorsToPause => _actorsToPause;

    public bool RegisterActor(IActor actor)
    {
        if (!_actorsToPause.Contains(actor))
        {
            _actorsToPause.Add(actor);
            return true;
        }

        return false;
    }

    public void UnregisterActor(IActor actor)
    {
        if (_actorsToPause.Contains(actor))
        {
            _actorsToPause.Remove(actor);
        }
        else
            Debug.LogError($"There was no actor {actor} registered");
    }
    
    public void SetPause()
    {
        foreach (var actor in _actorsToPause)
            actor.SetPause(true);
    }

    public void ResetPause()
    {
        foreach (var actor in _actorsToPause)
            actor.SetPause(false);
    }
}

public interface IPauseController : IPauseRegister
{
    public List<IActor> ActorsToPause { get; }

    public void SetPause();
    public void ResetPause();
}

public interface IPauseRegister
{
    public bool RegisterActor(IActor actor);
    public void UnregisterActor(IActor actor);
}
