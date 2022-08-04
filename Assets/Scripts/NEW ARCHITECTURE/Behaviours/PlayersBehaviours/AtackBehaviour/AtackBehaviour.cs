
    public abstract class AtackBehaviour<T> : BaseBehaviour, IAtackBehaviour
    {
        protected T _attacker;
        protected AtackStates _currentState;

        protected AtackBehaviour(T attacker)
        {
            this._attacker = attacker;
        }
    }

    public enum AtackStates { DEFAULT ,ATACK, PAUSE, UNPAUSE, }

    public interface IAtackBehaviour : IBehaviour
    {
    }

