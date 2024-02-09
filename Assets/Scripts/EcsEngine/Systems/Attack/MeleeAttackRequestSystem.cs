using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Helpers;

namespace EcsEngine.Systems.Attack
{
    public class MeleeAttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<DamagableTag> damagableTagPool;
        private readonly EcsPoolInject<DeathRequest> deathRequestPool;
        private readonly EcsFilterInject<Inc<AttackRequest, MeleeWeapon, TargetEntity, Damage>, Exc<Inactive>> filter;

        private readonly EcsFactoryInject<TakeDamageRequest, SourceEntity, TargetEntity, Damage> takeDamageEmitter
            = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var requestPool = filter.Pools.Inc1;

            var targetPool = filter.Pools.Inc3;
            var damagePool = filter.Pools.Inc4;

            foreach (var entity in filter.Value)
            {
                var targetEntity = targetPool.Get(entity);
                if (targetEntity.value == -1)
                    continue;

                var target = targetEntity.value;

                if (!damagableTagPool.Value.Has(target)) continue;

                takeDamageEmitter.Value.NewEntity(
                    new TakeDamageRequest(),
                    new SourceEntity { value = entity },
                    targetEntity,
                    damagePool.Get(entity)
                );
                requestPool.Del(entity);
            }
        }
    }
}