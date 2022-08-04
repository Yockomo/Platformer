using UnityEngine;

    public abstract class BehaviourContainer<T> : MonoBehaviour where T : IBehaviour
    {
        public abstract T GetValue { get; }
        
        private void Awake()
        {
            if (TryGetComponent<ICanSetBehaviour>(out var behaviourOwner))
            {
                Init();

                if (GetValue != null)
                    behaviourOwner.AddBehaviour(GetValue);
                else
                    Debug.LogError("Behaviour was not initialized in container on " + gameObject.name);
            }
            else
                Debug.LogError($"There is no Actor for behaviour on {gameObject.name}");
        }

        protected abstract void Init();
    }
    
public abstract class MoveBehaviourContainer : BehaviourContainer<IMoveBehaviour> 
{
}

public interface IMoveBehaviour : IBehaviour
{
}