using Game.Entities.Common.Components;
using Game.TurnSystem.Events;
using UnityEngine;

namespace Game.TurnSystem.Handlers
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
            Debug.Log("inited");
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            if (!evt.Entity.TryGet(out Health health))
                return;
            var prevHealth = health.Value;
            health.Value -= evt.Damage;
            Debug.Log(prevHealth+"/"+health.Value);
            if (health.Value <= 0) EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}