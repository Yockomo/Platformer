using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GetPlayerBind : MonoInstaller
{
    [SerializeField] private Player _playerInstance;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_playerInstance).AsSingle().NonLazy();

        var playerInput = _playerInstance.GetComponent<InputSystem>();
        Container.Bind<InputSystem>().FromInstance(playerInput).AsSingle().NonLazy();
        
        var pauseController = new PauseController();
        Container.Bind<IPauseController>().FromInstance(pauseController).AsSingle().NonLazy();
        Container.Bind<IPauseRegister>().FromInstance(pauseController).AsSingle().NonLazy();
    }
}