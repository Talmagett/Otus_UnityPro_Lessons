using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class EnemyInRangeCheckSystem: IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TargetEntity, MoveToTargetTag, Position, AttackRange>, Exc<Inactive, HasEnemyInRangeTag>> filter;
        
        private readonly EcsPoolInject<Position> positionPool;
        private readonly EcsPoolInject<HasEnemyInRangeTag> enemiesInAttackRangePool;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                ref var targetEntity = ref filter.Pools.Inc1.Get(entity);
                if (targetEntity.value == -1)
                    continue;
                
                ref var targetPos = ref positionPool.Value.Get(targetEntity.value);
                ref var entityPos = ref filter.Pools.Inc3.Get(entity);

                if (Vector3.Distance(targetPos.value, entityPos.value) >= filter.Pools.Inc4.Get(entity).value)
                    continue;

                enemiesInAttackRangePool.Value.Add(entity) = new HasEnemyInRangeTag();
            }
        }
    }
}