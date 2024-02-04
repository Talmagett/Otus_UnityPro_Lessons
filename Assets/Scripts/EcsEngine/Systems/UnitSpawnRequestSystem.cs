using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class UnitSpawnRequestSystem: IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnRequest, UnitSpawnData>, Exc<Inactive>> filter;
        
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        
        private readonly EcsPoolInject<SpawnRequest> spawnPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Position> positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> prefabPool = EcsWorlds.Events;
        private readonly EcsPoolInject<PlayerID> playerIdPool = EcsWorlds.Events;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsPool<SpawnRequest> requestPool = this.filter.Pools.Inc1;
            EcsPool<UnitSpawnData> unitSpawnDataPool = this.filter.Pools.Inc2;

            foreach (int entity in this.filter.Value)
            {
                var unitSpawnData = unitSpawnDataPool.Get(entity);
                
                //Spawn bullet...
                int spawnEvent = this.eventWorld.Value.NewEntity();
                
                this.spawnPool.Value.Add(spawnEvent) = new SpawnRequest();
                this.positionPool.Value.Add(spawnEvent) = new Position {value = unitSpawnData.spawnPoint};
                this.rotationPool.Value.Add(spawnEvent) = new Rotation {value = unitSpawnData.rotation};
                this.prefabPool.Value.Add(spawnEvent) = new Prefab {value = unitSpawnData.spawnPrefab};
                this.playerIdPool.Value.Add(spawnEvent) = new PlayerID {value = unitSpawnData.playerId};
                
                Debug.Log($"Pew {unitSpawnData.spawnPrefab.name}!");
                unitSpawnDataPool.Del(entity);
                requestPool.Del(entity);
            }
        }
        
    }
}