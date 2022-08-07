using System.Collections;
using UnityEngine;

public class PlatformDamageableComponent : MonoBehaviour
{
    [SerializeField] private int _damagePerHit;
    [SerializeField] private float _timeBetweenHits;

    private IActivatedActor _activatedActor;
    private bool _isActive;

    private void Start()
    {
        if(TryGetComponent<IActivatedActor>(out var actor))
        {
            _activatedActor = actor;
        }
        else
            Debug.LogError("There is no Actor with IActivatedActor interface on" + gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isActive && other.TryGetComponent<Health>(out var health))
        {
            _isActive = true;
            StartCoroutine(DealDamage(health));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            _isActive = false;
        }
    }
    
    private IEnumerator DealDamage(Health health)
    {
        while (_activatedActor.IsActive)
        {
            health.DecValue(_damagePerHit);
            yield return new WaitForSecondsRealtime(_timeBetweenHits);   
        }
    }
}