using TurnSystem.Events;

namespace TurnSystem.Handlers
{
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        public DestroyHandler(EventBus eventBus) : base(eventBus)
        {
        }
        
        protected override void HandleEvent(DestroyEvent evt)
        {
            /*if (evt.Entity.TryGet(out DeathComponent deathComponent))
            {
                deathComponent.Die();
            }*/

            //
            // // Visual
            // if (evt.Entity.TryGet(out DestroyComponent destroyComponent))
            // {
            //     destroyComponent.Destroy();
            // }
        }
    }
}