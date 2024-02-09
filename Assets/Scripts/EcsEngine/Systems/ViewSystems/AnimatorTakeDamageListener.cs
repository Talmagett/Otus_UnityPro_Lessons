using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    internal sealed class AnimatorTakeDamageListener : IEcsRunSystem
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        private readonly EcsPoolInject<AnimatorView> animatorPool;

        private readonly EcsFilterInject<Inc<TakeDamageEvent, TargetEntity>> filter = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var @event in filter.Value)
            {
                var target = filter.Pools.Inc2.Get(@event).value;

                if (!animatorPool.Value.Has(target)) continue;

                var animator = animatorPool.Value.Get(target).value;
                animator.SetTrigger(TakeDamage);
            }
        }
    }
}