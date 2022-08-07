using UnityEngine;

public class HealComponent : MonoBehaviour
{
    [SerializeField] private int _pointsToHeal;

    private ActivatedActor _activatedActor;
    private PlayerHealthComponent _playerHealth;

    private void Start()
    {
        if (TryGetComponent<ActivatedActor>(out var activatedActor))
        {
            _activatedActor = activatedActor;
            _activatedActor.OnActivationEvent += RestoreHealth;
        }
        else
            Debug.LogError("There is no Activated Actor component on " + gameObject.name);
    }

    private void RestoreHealth()
    {
        if (_playerHealth == null && _activatedActor.Activator.TryGetComponent<PlayerHealthComponent>(out var healthComponent))
        {
            _playerHealth = healthComponent;
        }

        if (_playerHealth != null)
        {
            _playerHealth.AddValue(_pointsToHeal);
            gameObject.SetActive(false);
        }
    }
}
