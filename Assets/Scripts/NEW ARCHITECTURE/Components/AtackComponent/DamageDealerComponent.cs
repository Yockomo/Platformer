using UnityEngine;

public abstract class DamageDealerComponent : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected LayerMask damageTo;
    [SerializeField] protected float hitRadius;
    [SerializeField] protected float hitDistance;
    [SerializeField] protected int countToDamage;

    protected virtual void Start() 
    {
        Init();
    }

    protected virtual void Init()
    {
    }

    public virtual void Attack()
    {
        DamageSphereCast damageSphereCast = new DamageSphereCast();
        damageSphereCast.AttackSphereCast(this.transform, damage, hitDistance, hitRadius, countToDamage, damageTo);
    }
}