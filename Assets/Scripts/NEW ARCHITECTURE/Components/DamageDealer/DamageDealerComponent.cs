using UnityEngine;

public abstract class DamageDealerComponent : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected LayerMask damageTo;
    [SerializeField] protected float hitRadius;
    [SerializeField] protected float hitDistance;
    [SerializeField] protected int countToDamage;

    protected DamageSphereCast _damageSphereCast;
    
    protected virtual void Start() 
    {
        Init();
    }

    protected virtual void Init()
    {
        _damageSphereCast = new DamageSphereCast();
    }

    public virtual void Attack()
    {
        _damageSphereCast.AttackSphereCast(this.transform, damage, hitDistance, hitRadius, countToDamage, damageTo);
    }
}