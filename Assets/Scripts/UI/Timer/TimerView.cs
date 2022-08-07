using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerView : MonoBehaviour
{
    private TextMeshProUGUI _timeText;
    
    [SerializeField] private GameTimeController _timeController;
    
    private void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(DrawTimeText());
    }

    private IEnumerator DrawTimeText()
    {
        while (true)
        {
            _timeText.text = "Осталось " + _timeController.GetCurrentTime() + " секунд";
            yield return new WaitForSeconds(1f);   
        }
    }
}
