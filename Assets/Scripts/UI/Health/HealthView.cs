using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    private Image _healthBar;
    
    [Inject]
    private void Contsruct(Player _player)
    {
        _healthBar = GetComponent<Image>();
        _player.GetComponent<PlayerHealthComponent>().Changed += DrawBar;
    }

    private void DrawBar(int maxValue, int currentValue)
    {
        _healthBar.fillAmount = (float) currentValue / maxValue;
    }
}
