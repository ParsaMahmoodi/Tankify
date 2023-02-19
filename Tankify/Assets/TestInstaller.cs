using Features.Core.Scripts;
using Features.Core.Scripts.Player;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        // Container.Bind<GameManager>().AsSingle().NonLazy();
        // //Container.Bind<GameObject>().player
        //
        // Container.BindFactory<PlayerController, PlayerController.Factory>().FromNew();
    }
    
}
