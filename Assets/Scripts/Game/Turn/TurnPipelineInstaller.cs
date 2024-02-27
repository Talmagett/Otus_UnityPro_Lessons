using Game.Installers;
using Game.Tasks.Turn;
using Game.TurnSystem;
using Game.Visual;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Turn
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller : IInitializable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly DiContainer _diContainer;
        
        public TurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer diContainer)
        {
            _turnPipeline = turnPipeline;
            _diContainer = diContainer;
        }

        void IInitializable.Initialize()
        {
            var eventBus = _diContainer.Resolve<EventBus>();
            var visualPipeline = _diContainer.Resolve<VisualPipeline>();
            var heroTurnController = _diContainer.Resolve<HeroTurnController>();
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(new PlayerTurnTask(eventBus,heroTurnController));
            _turnPipeline.AddTask(new VisualTurnTask(visualPipeline));
            _turnPipeline.AddTask(new FinishTurnTask());
        }
    }
}