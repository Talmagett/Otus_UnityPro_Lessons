using EcsEngine.Components;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class TargetSelectorSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<TargetEntity,PlayerID, Position>, Exc<Inactive>> filter;
        private EcsFilterInject<Inc<DamagableTag, PlayerID, Position>, Exc<Inactive>> targetFilter;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var distance = float.PositiveInfinity;
                
                ref var targetEntity = ref filter.Pools.Inc1.Get(entity);
                
                var checkingTarget = entity;
                foreach (var iteratingTargetEntities in targetFilter.Value)
                {
                    if (entity == iteratingTargetEntities)
                        continue;
                    if (filter.Pools.Inc2.Get(entity).value == targetFilter.Pools.Inc2.Get(iteratingTargetEntities).value)
                        continue;
                    
                    var entityPos = filter.Pools.Inc3.Get(entity).value;
                    var targetPos = targetFilter.Pools.Inc3.Get(iteratingTargetEntities).value;

                    var checkingDistance = Vector3.Distance(entityPos, targetPos);

                    if (checkingDistance >= distance) 
                        continue;
                    
                    distance = checkingDistance;
                    checkingTarget = iteratingTargetEntities;
                }

                if (checkingTarget == entity)
                {
                    targetEntity.value = -1;
                    continue;
                }

                targetEntity.value = checkingTarget;
            }
        }
    }
}