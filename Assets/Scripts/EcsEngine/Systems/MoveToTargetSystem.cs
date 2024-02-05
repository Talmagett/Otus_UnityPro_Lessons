using EcsEngine.Components;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class MoveToTargetSystem: IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveToTargetTag, MoveSpeed, Position,TargetEntity>, Exc<Inactive>> filter;
        
        private readonly EcsPoolInject<Inactive> inactivePool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            var speedPool = filter.Pools.Inc2;
            var positionPool = filter.Pools.Inc3;
            var targetPool = filter.Pools.Inc4;
            
            foreach (var entity in filter.Value)
            {
                var targetEntity = targetPool.Get(entity).value;
                if (inactivePool.Value.Has(targetEntity))
                {
                    targetPool.Del(entity);
                    continue;
                }

                ref var targetPos = ref positionPool.Get(targetEntity);
                ref var entityPos = ref positionPool.Get(entity);
                var moveDirection = (targetPos.value - entityPos.value).normalized;
                var moveSpeed = speedPool.Get(entity);

                entityPos.value =Vector3.MoveTowards(entityPos.value, targetPos.value, moveSpeed.value * deltaTime);
                //entityPos.value += moveDirection * (moveSpeed.value * deltaTime);
            }
        }
    }
}