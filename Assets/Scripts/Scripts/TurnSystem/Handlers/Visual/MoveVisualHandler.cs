using Lessons.Level;
using Lessons.Tasks.Visual;
using Lessons.TurnSystem.Events;
using Lessons.Visual;

namespace Lessons.TurnSystem.Handlers.Visual
{
    public sealed class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly LevelMap _levelMap;
        
        public MoveVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, LevelMap levelMap) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _levelMap = levelMap;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            var targetPosition = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition, 0.3f, evt.IsForced));
        }
    }
}