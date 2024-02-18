using JetBrains.Annotations;
using Systems;
using Zenject;

[UsedImplicitly]
public class GameInstaller : MonoInstaller
{
    //[SerializeField]
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
    }
}