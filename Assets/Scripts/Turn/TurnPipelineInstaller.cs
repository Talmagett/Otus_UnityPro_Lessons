using Zenject;

namespace Turn
{
    public sealed class TurnPipelineInstaller : IInitializable
    {
        /*private readonly TurnPipeline _turnPipeline;
        private readonly IObjectResolver _objectResolver;
        
        public TurnPipelineInstaller(TurnPipeline turnPipeline, IObjectResolver objectResolver)
        {
            _turnPipeline = turnPipeline;
            _objectResolver = objectResolver;
        }
        
        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<PlayerTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<VisualTurnTask>());
            _turnPipeline.AddTask(new FinishTurnTask());
        }*/
        public void Initialize()
        {
            
        }
    }
}