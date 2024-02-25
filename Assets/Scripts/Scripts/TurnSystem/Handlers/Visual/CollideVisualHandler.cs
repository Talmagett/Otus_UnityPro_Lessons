using Lessons.Entities.Common.Components;
using Lessons.Tasks.Visual;
using Lessons.TurnSystem.Events;
using Lessons.Visual;

namespace Lessons.TurnSystem.Handlers.Visual
{
    public sealed class CollideVisualHandler : BaseHandler<CollideEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public CollideVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(CollideEvent evt)
        {
            var sourcePosition = evt.Entity.Get<PositionComponent>();
            var targetPosition = evt.Target.Get<PositionComponent>();
            var offset = (targetPosition.Value - sourcePosition.Value) * 0.5f;
            
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value + offset, 0.15f));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value, 0.15f));
        }
    }
}