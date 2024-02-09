using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Life
{
    public class UnitSpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsFilterInject<Inc<SpawnRequest, UnitSpawnData>, Exc<Inactive>> filter;
        private readonly EcsPoolInject<MaterialView> materialViewPool = EcsWorlds.Events;
        private readonly EcsPoolInject<PlayerID> playerIdPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Position> positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> prefabPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<SpawnRequest> spawnPool = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var requestPool = filter.Pools.Inc1;
            var unitSpawnDataPool = filter.Pools.Inc2;

            foreach (var entity in filter.Value)
            {
                var unitSpawnData = unitSpawnDataPool.Get(entity);

                var spawnEvent = eventWorld.Value.NewEntity();

                spawnPool.Value.Add(spawnEvent) = new SpawnRequest();
                var randPos = Random.insideUnitSphere * 5;
                randPos.y = 0;
                positionPool.Value.Add(spawnEvent) = new Position { value = unitSpawnData.spawnPoint + randPos };
                rotationPool.Value.Add(spawnEvent) = new Rotation { value = unitSpawnData.rotation };
                prefabPool.Value.Add(spawnEvent) = new Prefab { value = unitSpawnData.spawnPrefab };
                playerIdPool.Value.Add(spawnEvent) = new PlayerID { value = unitSpawnData.playerId };
                materialViewPool.Value.Add(spawnEvent) = new MaterialView { value = unitSpawnData.spawnMaterial };
                Debug.Log($"Spawn {unitSpawnData.spawnPrefab.name}!");
                unitSpawnDataPool.Del(entity);
                requestPool.Del(entity);
            }
        }
    }
}