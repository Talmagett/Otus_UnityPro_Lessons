using EcsEngine.Components.Attack;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    public class AnimatorMoveListener: IEcsRunSystem
    {
        private readonly EcsPoolInject<AnimatorView> animatorPool;

        private readonly EcsFilterInject<Inc<MoveToTargetTag>> filter;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                if (!animatorPool.Value.Has(entity)) continue;
                
                var isMoving = filter.Pools.Inc1.Get(entity).IsMoving;
                var animator = animatorPool.Value.Get(entity).value;
                animator.SetBool(IsMoving,isMoving);
            }
        }
    }
}