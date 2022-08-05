using UnityEngine;

public class ScoreUpComponent : MonoBehaviour
{
    [SerializeField] private int _pointsPickUp;

    private ActivatedActor _activatedActor;
    private IScoreKeeper _scoreKeeper;

    private void Start()
    {
        if (TryGetComponent<ActivatedActor>(out var activatedActor))
        {
            _activatedActor = activatedActor;
            _activatedActor.OnActivationEvent += ScoreUp;
        }
        else
            Debug.LogError("There is no Activated Actor component on " + gameObject.name);
    }

    private void ScoreUp()
    {
        if (_scoreKeeper == null && _activatedActor.Activator.TryGetComponent<IScoreKeeper>(out var keeper))
        {
            _scoreKeeper = keeper;
        }

        if (_scoreKeeper != null)
        {
            _scoreKeeper.ScoreUp(_pointsPickUp);
            gameObject.SetActive(false);
        }
    }
}
