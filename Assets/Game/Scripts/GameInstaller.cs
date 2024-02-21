using Entity;
using JetBrains.Annotations;
using Systems;
using UnityEngine;
using Zenject;

[UsedImplicitly]
public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterEntity player;
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
        Container.BindInstance(player).AsSingle();
    }
}