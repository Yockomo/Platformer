using UnityEngine;
using Zenject;

public class GameTimeController : MonoBehaviour, IActor
{
    [SerializeField] private float _timeForLevelCompletion;

    private TimeKeeper _timeKeeper;

    [Inject]
    private void Construct(IPauseRegister pauseRegister)
    {
        pauseRegister.RegisterActor(this);
    }
    
    private void Start()
    {
        _timeKeeper = new TimeKeeper(_timeForLevelCompletion);
        TrackTime();
    }

    public void SetPause(bool value)
    {
        _timeKeeper.SetPause(value);
        if (!value)
            TrackTime();
    }

    private void TrackTime()
    {
        StartCoroutine(_timeKeeper.CalculateCurrentTime());
    }
    
    public void AddBehaviour(IBehaviour behaviour)
    {
    }
}
