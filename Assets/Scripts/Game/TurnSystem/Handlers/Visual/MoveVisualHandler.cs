using Game.TurnSystem.Events;
using Game.Visual;

namespace Game.TurnSystem.Handlers.Visual
{
    public sealed class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public MoveVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            /*var targetPosition = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition, 0.3f, evt.IsForced));*/
        }
    }
}