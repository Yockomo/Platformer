using System;

public class PlayerHealthComponent : Health
{
    public event Action OnHpEndEvent;

    public override void DecValue(int count)
    {
        if (currentHealth > 0)
        {
            base.DecValue(count);
            if (currentHealth < 1)
            {
                OnHpEndEvent?.Invoke();   
            }   
        }
    }
}