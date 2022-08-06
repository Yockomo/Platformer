using System;
using UnityEngine;

public class PlayerHealthComponent : Health
{
    [SerializeField] private float hp;

    public event Action OnHpEndEvent;

    private void Update()
    {
        hp = currentHealth;
    }

    public override void DecValue(int count)
    {
        base.DecValue(count);
        if (currentHealth < 1)
        {
            OnHpEndEvent?.Invoke();   
        }
    }
}