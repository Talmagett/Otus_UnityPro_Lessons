using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;

namespace EcsEngine.Systems.Life
{
    internal sealed class SpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<EntityManager> entityManager;
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;

        private readonly EcsFilterInject<Inc<SpawnRequest, Position, Rotation, Prefab>> filter =
            EcsWorlds.Events;

        private readonly EcsPoolInject<MaterialView> materialPool = EcsWorlds.Events;

        private readonly EcsPoolInject<PlayerID> playerIdPool = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var @event in filter.Value)
            {
                var position = filter.Pools.Inc2.Get(@event).value;
                var rotation = filter.Pools.Inc3.Get(@event).value;
                var prefab = filter.Pools.Inc4.Get(@event).value;

                var createdEntity = entityManager.Value.Create(prefab, position, rotation);

                if (materialPool.Value.Has(@event))
                    createdEntity.SetData(new MaterialView { value = materialPool.Value.Get(@event).value });

                if (playerIdPool.Value.Has(@event))
                    createdEntity.SetData(new PlayerID { value = playerIdPool.Value.Get(@event).value });
                createdEntity.SetData(new Init());
                eventWorld.Value.DelEntity(@event);
            }
        }
    }
}