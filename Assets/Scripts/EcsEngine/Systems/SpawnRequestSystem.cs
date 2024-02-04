using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;

namespace EcsEngine.Systems
{
    internal sealed class SpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<EntityManager> entityManager;
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;

        private readonly EcsFilterInject<Inc<SpawnRequest, Position, Rotation, Prefab, PlayerID>> filter =
            EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var @event in filter.Value)
            {
                var position = filter.Pools.Inc2.Get(@event).value;
                var rotation = filter.Pools.Inc3.Get(@event).value;
                var prefab = filter.Pools.Inc4.Get(@event).value;
                var playerTag = filter.Pools.Inc5.Get(@event).value;

                var createdEntity = entityManager.Value.Create(prefab, position, rotation);

                createdEntity.SetData(new PlayerID { value = playerTag });

                eventWorld.Value.DelEntity(@event);
            }
        }
    }
}