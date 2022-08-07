using TMPro;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public void SetFinalScore(int value)
    {
        SetText(_scoreText, $"Очков набрано - {value}");
    }
    
    public void SetFinalTime(int value)
    {
        SetText(_timeText, $"Времени осталось - {value}");
    }
    
    public void SetFinalScoreAndTime(int score, int time)
    {
        SetText(_scoreText, $"Очков набрано - {score}");
        SetText(_timeText, $"Времени осталось - {time}");
    }

    private void SetText(TextMeshProUGUI field, string text)
    {
        field.text = text;
    }
}
