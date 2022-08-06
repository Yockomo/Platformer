using UnityEngine;
using Zenject;

public class GetPauseBind : MonoInstaller
{
    public override void InstallBindings()
    {        
        var pauseController = new PauseController();
        Container.Bind<IPauseController>().FromInstance(pauseController).AsSingle().NonLazy();
        Container.Bind<IPauseRegister>().FromInstance(pauseController).AsSingle().NonLazy();
    }
}