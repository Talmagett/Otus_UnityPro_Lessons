using EcsEngine.Components.Life;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    internal sealed class AnimatorDeathListener : IEcsRunSystem
    {
        private static readonly int Death = Animator.StringToHash("Death");

        private readonly EcsFilterInject<Inc<AnimatorView, DeathEvent>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var animator = filter.Pools.Inc1.Get(entity).value;
                animator.SetTrigger(Death);
            }
        }
    }
}