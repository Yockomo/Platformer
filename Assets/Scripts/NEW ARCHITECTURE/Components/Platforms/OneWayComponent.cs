using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OneWayComponent : MonoBehaviour
{
    [SerializeField] private Vector3 _entryDirection = Vector3.up;
    private BoxCollider _collider;
    private BoxCollider _collisionTrigger;
    private float _triggerScale = 1.3f;

    private bool _isActive;
    
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = false;
        AddTriggerCollider();
    }
    
    
    private void AddTriggerCollider()
    {
        _collisionTrigger = gameObject.AddComponent<BoxCollider>();
        _collisionTrigger.size = _collider.size;
        _collisionTrigger.size = new Vector3(_collisionTrigger.size.x,_collisionTrigger.size.y * 5, _collisionTrigger.size.z);
        _collisionTrigger.center = _collider.center - _entryDirection;
        _collisionTrigger.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isActive)
        {
            _isActive = IsEntryDirection(other);
            Physics.IgnoreCollision(_collider,other,_isActive);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isActive = IsEntryDirection(other);
        Physics.IgnoreCollision(_collider,other,_isActive);
    }

    private bool IsEntryDirection(Collider other)
    {
        var dot = 0f;
        if (Physics.ComputePenetration(_collisionTrigger,transform.position,transform.rotation,
                other,other.transform.position,other.transform.rotation,out Vector3 direction,out float distance))
        {
            dot = Vector3.Dot(_entryDirection, direction);
        }

        return dot > 0;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,_entryDirection);        
        
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, -_entryDirection);
    }
}
