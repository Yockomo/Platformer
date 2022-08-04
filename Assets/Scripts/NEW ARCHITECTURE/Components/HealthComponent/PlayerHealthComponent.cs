using UnityEngine;

public class PlayerHealthComponent : Health
{
    [SerializeField] private float hp;

    private void Update()
    {
        hp = currentHealth;
    }
}