using UnityEngine;
using System;

public class PlayerScoreComponent : MonoBehaviour, IScoreKeeper
{
    public int Score { get; private set; }
    public event Action<int> OnScoreUpEvent;

    public void ScoreUp(int value)
    {
        if (value > 0)
        {
            Score += value;
            OnScoreUpEvent?.Invoke(Score);
        }
        else
            Debug.LogError("There was minus sign of value parameter");
    }
}

public interface IScoreKeeper
{
    int Score { get; }
    void ScoreUp(int value);
}