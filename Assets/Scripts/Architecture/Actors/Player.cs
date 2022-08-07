using UnityEngine;

public class Player : Actor, ICanAttack, IHaveAnimatorManager<PlayerAnimatorManager>
{
    private PlayerAnimatorManager _animatorManager;

    protected override void Init()
    {
    }

    public PlayerAnimatorManager GetAnimatorManager()
    {
        if (_animatorManager == null)
        {
            _animatorManager = new PlayerAnimatorManager(GetComponent<Animator>());
            return _animatorManager;
        }
        else
            return _animatorManager;
    }
}

public interface IHaveAnimatorManager<T> where T : AnimatorManager
{
    T GetAnimatorManager();
}
