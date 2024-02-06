using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Movement
{
    public class MoveToTargetSystem: IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveToTargetTag, MoveSpeed, Position, TargetEntity>, Exc<Inactive>> filter;
        
        private readonly EcsPoolInject<HasEnemyInRangeTag> enemyInRangePool;
        private readonly EcsPoolInject<Rotation> rotationPool;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            var speedPool = filter.Pools.Inc2;
            var positionPool = filter.Pools.Inc3;
            var targetPool = filter.Pools.Inc4;
            
            foreach (var entity in filter.Value)
            {
                var targetEntity = targetPool.Get(entity).value;

                ref var targetPos = ref positionPool.Get(targetEntity);
                ref var entityPos = ref positionPool.Get(entity);
                var moveSpeed = speedPool.Get(entity);

                var isMoving = !enemyInRangePool.Value.Has(entity); 
                
                filter.Pools.Inc1.Get(entity).IsMoving = isMoving;
                if (!isMoving)
                    continue;
                if (rotationPool.Value.Has(entity))
                {
                    rotationPool.Value.Get(entity).value=Quaternion.LookRotation(targetPos.value-entityPos.value);
                }

                entityPos.value = Vector3.MoveTowards(entityPos.value, targetPos.value, moveSpeed.value * deltaTime);
            }
        }
    }
}