
public class PlayerAttackBehaviourContainer : BehaviourContainer<AtackBehaviour<ICanAttack>>, ICanAttack
{
    private AtackBehaviour<ICanAttack> _playersAttackBehaviour;
    public override AtackBehaviour<ICanAttack> GetValue => _playersAttackBehaviour;
    
    protected override void Init()
    {
        var playersAnimatorManager = GetComponent<IHaveAnimatorManager<PlayerAnimatorManager>>().GetAnimatorManager();

        _playersAttackBehaviour = 
            new PlayerAttackBehaviour(this, GetComponent<InputSystem>(), playersAnimatorManager);
    }
    
}
