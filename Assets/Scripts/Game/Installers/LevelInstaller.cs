using Game.Installers;
using Game.Turn;
using Game.TurnSystem;
using Game.TurnSystem.Handlers;
using Game.TurnSystem.Handlers.Effect;
using Game.TurnSystem.Handlers.Visual;
using Game.Visual;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ConfigurePlayer(Container);
        ConfigureHandlers(Container);
        ConfigureTurn(Container);
        ConfigureVisual(Container);
    }

    private void ConfigurePlayer(DiContainer container)
    {
        container.BindInterfacesAndSelfTo<HeroTurnController>().AsSingle().NonLazy();
    }

    private void ConfigureHandlers(DiContainer container)
    {
        container.Bind<EventBus>().AsSingle().NonLazy();
        
        container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle().NonLazy();
        container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle().NonLazy();
        container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle().NonLazy();
    }

    private void ConfigureTurn(DiContainer container)
    {
        container.Bind<TurnPipeline>().AsSingle().NonLazy();
        container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle().NonLazy();
    }

    private void ConfigureVisual(DiContainer container)
    {
        container.Bind<VisualPipeline>().AsSingle().NonLazy();

        container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle().NonLazy();
    }
}