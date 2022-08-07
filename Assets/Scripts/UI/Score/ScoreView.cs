using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    [Inject]
    private void Construct(Player player)
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        player.GetComponent<PlayerScoreComponent>().OnScoreUpEvent += DrawScoreText;
    }

    private void DrawScoreText(int scoreValue)
    {
        _scoreText.text = "Очков " + scoreValue.ToString();
    }
}
