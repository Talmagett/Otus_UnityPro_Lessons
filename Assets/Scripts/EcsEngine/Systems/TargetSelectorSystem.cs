using System.Linq;
using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class TargetSelectorSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<TargetChooserTag, PlayerID, Position>,Exc<TargetEntity,Inactive>> filter;
        private EcsFilterInject<Inc<DamagableTag, PlayerID, Position>, Exc<Inactive>> targetFilter;
        
        private readonly EcsPoolInject<TargetEntity> targetPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var distance = float.PositiveInfinity;
                var targetEntity = entity;
                foreach (var checkingEntity in targetFilter.Value)
                {
                    if (entity == checkingEntity)
                        continue;
                    if (filter.Pools.Inc2.Get(entity).value == targetFilter.Pools.Inc2.Get(checkingEntity).value)
                        continue;
                    
                    var entityPos = filter.Pools.Inc3.Get(entity).value;
                    var targetPos = targetFilter.Pools.Inc3.Get(checkingEntity).value;

                    var checkingDistance = Vector3.Distance(entityPos, targetPos);
                    
                    if (checkingDistance < distance)
                    {
                        distance = checkingDistance;
                        targetEntity = checkingEntity;
                    }
                }

                if (targetEntity == entity)
                    continue;

                targetPool.Value.Add(entity) = new TargetEntity { value = targetEntity };
            }
        }
    }
}