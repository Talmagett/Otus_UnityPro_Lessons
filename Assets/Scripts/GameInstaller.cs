using Game.Gameplay.Player;
using Sample;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind<MoneyStorage>().AsSingle().NonLazy();
        Container.Bind<UpgradesManager>().AsSingle().NonLazy();
    }
}