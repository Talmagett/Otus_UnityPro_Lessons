using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Physics;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Helpers;

namespace EcsEngine.Systems.Attack
{
    internal sealed class BulletCollisionRequestSystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<DamagableTag> damagableTagPool;

        private readonly EcsPoolInject<Damage> damagePool;
        private readonly EcsPoolInject<DeathRequest> deathRequestPool;

        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;

        private readonly EcsFilterInject<Inc<CollisionEnterRequest, BulletTag, SourceEntity, TargetEntity>> filter =
            EcsWorlds.Events;

        private readonly EcsFactoryInject<TakeDamageRequest, SourceEntity, TargetEntity, Damage> takeDamageEmitter
            = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var sourcePool = filter.Pools.Inc3;
            var targetPool = filter.Pools.Inc4;

            foreach (var entity in filter.Value)
            {
                //Удаление запроса:

                var sourceEntity = sourcePool.Get(entity);
                var bullet = sourceEntity.value;

                if (!deathRequestPool.Value.Has(bullet))
                {
                    var targetEntity = targetPool.Get(entity);
                    var target = targetEntity.value;

                    if (damagableTagPool.Value.Has(target))
                        //Deal damage:
                        takeDamageEmitter.Value.NewEntity(
                            new TakeDamageRequest(),
                            sourceEntity,
                            targetEntity,
                            damagePool.Value.Get(bullet)
                        );

                    //Пометить пулю неактивной
                    deathRequestPool.Value.Add(bullet);
                }

                eventWorld.Value.DelEntity(entity);
            }
        }
    }
}