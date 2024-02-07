using EcsEngine.Components;
using EcsEngine.Components.Attack;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class ArcherAttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsFilterInject<Inc<AttackRequest, ArcherWeapon, TargetEntity, PlayerID>, Exc<Inactive>> filter;
        
        private readonly EcsPoolInject<SpawnRequest> spawnPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Position> positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> prefabPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<PlayerID> playerIdPool = EcsWorlds.Events;
        
        // ReSharper disable Unity.PerformanceAnalysis
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var requestPool = filter.Pools.Inc1;
            var weaponPool = filter.Pools.Inc2;
            
            foreach (var entity in filter.Value)
            {
                var weapon = weaponPool.Get(entity);

                //Spawn arrow...
                var spawnEvent = eventWorld.Value.NewEntity();
                var playerId = filter.Pools.Inc4.Get(entity).value;

                spawnPool.Value.Add(spawnEvent) = new SpawnRequest();
                positionPool.Value.Add(spawnEvent) = new Position { value = weapon.firePoint.position };
                rotationPool.Value.Add(spawnEvent) = new Rotation { value = weapon.firePoint.rotation };
                prefabPool.Value.Add(spawnEvent) = new Prefab { value = weapon.arrowPrefab };
                playerIdPool.Value.Add(spawnEvent) = new PlayerID { value = playerId };

                Debug.Log($"Pew {weapon.arrowPrefab.name}!");
                requestPool.Del(entity);
            }
        }
    }
}