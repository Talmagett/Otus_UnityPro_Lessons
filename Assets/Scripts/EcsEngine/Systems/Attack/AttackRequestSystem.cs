using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Attack
{
    public class AttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<AttackRequest> attackPool;

        private readonly EcsFilterInject<Inc<TargetEntity, HasEnemyInRangeTag, Cooldown>, Exc<Inactive, AttackRequest>>
            filter;

        private EcsPoolInject<AttackEvent> eventPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var cooldownPool = filter.Pools.Inc3;
            var hasEnemyPool = filter.Pools.Inc2;
            foreach (var entity in filter.Value)
            {
                if (!cooldownPool.Get(entity).canUse)
                    continue;

                ref var cooldown = ref cooldownPool.Get(entity);
                cooldown.value = cooldown.maxValue;

                attackPool.Value.Add(entity) = new AttackRequest();
                eventPool.Value.Add(entity) = new AttackEvent();
                hasEnemyPool.Del(entity);
            }
        }
    }
}