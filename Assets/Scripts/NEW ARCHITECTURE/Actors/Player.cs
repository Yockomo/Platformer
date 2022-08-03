using UnityEngine;

public class Player : Actor, ICanAtack, IHaveAnimatorManager<PlayerAnimatorManager>
{
    private PlayerAnimatorManager _animatorManager;
    public PlayerAnimatorManager AnimatorManager
    {
        get
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

    protected override void Init()
    {
    }
}

public interface IHaveAnimatorManager<T> where T : AnimatorManager
{
    T AnimatorManager { get; }
}
