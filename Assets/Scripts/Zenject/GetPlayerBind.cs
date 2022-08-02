using UnityEngine;
using Zenject;

public class GetPlayerBind : MonoInstaller
{
    [SerializeField] private Player playerInstance;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}