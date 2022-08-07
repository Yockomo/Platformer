using System;
using UnityEngine;
using Zenject;

public class GameTimeController : MonoBehaviour, IActor
{
    [SerializeField] private float _timeForLevelCompletion;

    private TimeKeeper _timeKeeper;

    public event Action TimeEndedEvent;

    [Inject]
    private void Construct(IPauseRegister pauseRegister)
    {
        pauseRegister.RegisterActor(this);
        _timeKeeper = new TimeKeeper(_timeForLevelCompletion);
        TrackTime();
        _timeKeeper.EndTimeEvent += TimeEnded;
    }

    private void TrackTime()
    {
        StartCoroutine(_timeKeeper.CalculateCurrentTime());
    }
    
    public void SetPause(bool value)
    {
        _timeKeeper.SetPause(value);
        if (!value)
            TrackTime();
    }

    private void TimeEnded()
    {
        TimeEndedEvent?.Invoke();
    }

    public float GetCurrentTime()
    {
        return _timeKeeper.Time;
    }
    
    public void AddBehaviour(IBehaviour behaviour)
    {
    }
}
