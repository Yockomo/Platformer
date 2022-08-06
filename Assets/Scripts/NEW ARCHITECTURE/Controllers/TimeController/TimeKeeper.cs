using System;
using System.Collections;
using UnityEngine;

public class TimeKeeper: ICanBePaused
{
    private float _currentTime;
    public float Time => _currentTime;
    
    public bool IsPaused { get; private set; }
    
    public event Action EndTimeEvent;
    
    public TimeKeeper(float maxTime)
    {
        _currentTime = maxTime;
    }
    
    public void SetPause(bool value)
    {
        IsPaused = value;
    }

    public IEnumerator CalculateCurrentTime()
    {
        while (_currentTime > 0 && !IsPaused)
        {
            _currentTime -= 1f;
            yield return new WaitForSecondsRealtime(1f);
            CheckEndEvent();
        }
    }

    private void CheckEndEvent()
    {
        if(_currentTime < 1)
            EndTimeEvent?.Invoke();
    }
}