using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
    public class EnemyChaiseBehaviourContainer : MoveBehaviourContainer
    {
        [SerializeField] private EnemyMovementAndAtackConfig enemyMoveConfig = default;
        [SerializeField] private bool animateMovement;
        
        private EnemyChaisePlayerMoveBehaviour _enemyChaisePlayerLogic;
        private Transform _playersTransform;
        
        public override IMoveBehaviour GetValue => _enemyChaisePlayerLogic;

        [Inject]
        private void Construct(Player player)
        {
            _playersTransform = player.GetComponent<Transform>();
        }
        
        protected override void Init()
        {
            if (animateMovement)
            {
                _enemyChaisePlayerLogic = new EnemyChaisePlayerMoveBehaviour(null, enemyMoveConfig, transform, 
                    _playersTransform, GetComponent<NavMeshAgent>(),GetComponent<IHaveMoveAnimation>());   
            }
            else
            {
                _enemyChaisePlayerLogic = new EnemyChaisePlayerMoveBehaviour
                    (null, enemyMoveConfig, transform,_playersTransform, GetComponent<NavMeshAgent>());
            }
        }
    }
