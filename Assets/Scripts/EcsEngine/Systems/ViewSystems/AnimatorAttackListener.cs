using EcsEngine.Components.Attack;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    public class AnimatorAttackListener : IEcsRunSystem
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private readonly EcsFilterInject<Inc<AnimatorView, AttackEvent>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var animator = filter.Pools.Inc1.Get(entity).value;
                animator.SetTrigger(Attack);
            }
        }
    }
}