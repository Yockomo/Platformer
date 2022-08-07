using TMPro;
using UnityEngine;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] private Color _colorToHighLight;
    
    private TextMeshProUGUI _text;
    private Color _defaultColor;
    
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _defaultColor = _text.color;
    }

    public void ChangeColor(bool change)
    {
        _text.color = change ? _colorToHighLight : _defaultColor;
    }
}
