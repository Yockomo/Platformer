using UnityEngine;

public class PlayerScoreComponent : MonoBehaviour, IScoreKeeper
{
    public int Score { get; private set; }
    
    public void ScoreUp(int value)
    {
        if(value > 0)
            Score += value;
        else
            Debug.LogError("There was minus sign of value parameter");
    }
}

public interface IScoreKeeper
{
    int Score { get; }
    void ScoreUp(int value);
}