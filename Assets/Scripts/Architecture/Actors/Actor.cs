using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Actor : MonoBehaviour, IActor
{
    protected List<IBehaviour> behaviours = new List<IBehaviour>(20);

    [Inject]
    protected virtual void Construct(IPauseRegister pauseRegister)
    {
        pauseRegister.RegisterActor(this);
    }
    
    protected virtual void Start()
    {
        Init();
    }

    protected abstract void Init();

    protected virtual void Update()
    {
        for (int i = 0; i < behaviours.Count; i++)
            behaviours[i].UpdateBehaviour();
    }

    public void AddBehaviour(IBehaviour behaviour)
    {
        if (behaviours.Contains(behaviour))
            return;
        behaviours.Add(behaviour);
        behaviour.Actor = this;
    }

    public virtual void SetPause(bool value)
    {
        if (value)
            foreach (var b in behaviours)
                b.Pause();
        else
            foreach (var b in behaviours)
                b.UnPause();
    }
}
