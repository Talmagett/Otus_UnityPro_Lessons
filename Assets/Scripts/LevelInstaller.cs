using Game;
using Lessons.Game;
using Turn;
using TurnSystem;
using TurnSystem.Handlers;
using TurnSystem.Handlers.Effect;
using TurnSystem.Handlers.Visual;
using Visual;
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
        container.BindInterfacesAndSelfTo<MouseInput>().AsSingle().NonLazy();
        container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
    }
    
    private void ConfigureHandlers(DiContainer container)
    {
        container.Bind<EventBus>().AsSingle().NonLazy();

        //container.Bind<ApplyDirectionHandler>().AsSingle().NonLazy();
        //container.Bind<ForceDirectionHandler>().AsSingle().NonLazy();
        container.Bind<AttackHandler>().AsSingle().NonLazy();
        //container.Bind<CollideHandler>().AsSingle().NonLazy();
        container.Bind<DealDamageHandler>().AsSingle().NonLazy();
        //container.Bind<MoveHandler>().AsSingle().NonLazy();
        //container.Bind<DestroyHandler>().AsSingle().NonLazy();
            
        container.Bind<DealDamageEffectHandler>().AsSingle().NonLazy();
        container.Bind<PushEffectHandler>().AsSingle().NonLazy();
    }
        
    private void ConfigureTurn(DiContainer container)
    {
        container.Bind<TurnPipeline>().AsSingle().NonLazy();
            
        //container.Bind<TurnRunner>().AsSingle().NonLazy();
        container.Bind<TurnPipelineInstaller>().AsSingle().NonLazy();
    }
        
    private void ConfigureVisual(DiContainer container)
    {
        container.Bind<VisualPipeline>().AsSingle().NonLazy();
            
        //container.Bind<MoveVisualHandler>().AsSingle().NonLazy();
        container.Bind<DestroyVisualHandler>().AsSingle().NonLazy();
        container.Bind<DealDamageVisualHandler>().AsSingle().NonLazy();
        container.Bind<AttackVisualHandler>().AsSingle().NonLazy();
            
        container.Bind<CollideVisualHandler>().AsSingle().NonLazy();
    }
}