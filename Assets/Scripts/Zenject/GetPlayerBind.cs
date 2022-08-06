using UnityEngine;
using Zenject;

public class GetPlayerBind : MonoInstaller
{
    [SerializeField] private Player _playerInstance;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_playerInstance).AsSingle().NonLazy();

        var playerInput = _playerInstance.GetComponent<InputSystem>();
        Container.Bind<InputSystem>().FromInstance(playerInput).AsSingle().NonLazy();
    }
}