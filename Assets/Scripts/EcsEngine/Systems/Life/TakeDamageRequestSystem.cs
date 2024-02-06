using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Life
{
    internal sealed class TakeDamageRequestSystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<TakeDamageEvent> eventPool = EcsWorlds.Events;

        private readonly EcsFilterInject<Inc<TakeDamageRequest, TargetEntity, Damage>, Exc<Inactive>> filter =
            EcsWorlds.Events;

        private readonly EcsPoolInject<Health> healthPool;
        private readonly EcsPoolInject<OneFrame> oneFramePool = EcsWorlds.Events;

        private readonly EcsWorldInject world;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var @event in filter.Value)
            {
                var target = filter.Pools.Inc2.Get(@event).value;
                var damage = filter.Pools.Inc3.Get(@event).value;

                if (world.Value.IsEntityAlive(target) && healthPool.Value.Has(target))
                {
                    ref var health = ref healthPool.Value.Get(target).value;
                    health = Mathf.Max(0, health - damage);
                }

                filter.Pools.Inc1.Del(@event);
                eventPool.Value.Add(@event) = new TakeDamageEvent();
                oneFramePool.Value.Add(@event) = new OneFrame();
            }
        }
    }
}