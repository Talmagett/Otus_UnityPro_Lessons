using Tasks.Visual;
using TurnSystem.Events;
using Visual;

namespace TurnSystem.Handlers.Visual
{
    public class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public DealDamageVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            _visualPipeline.AddTask(new DealDamageVisualTask(evt.Entity, 0.15f));
        }
    }
}