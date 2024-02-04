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
    internal sealed class FireRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsFilterInject<Inc<FireRequest, BulletWeapon>, Exc<Inactive>> filter;
        private readonly EcsPoolInject<Position> positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> prefabPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<SpawnRequest> spawnPool = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var weaponPool = filter.Pools.Inc2;
            var requestPool = filter.Pools.Inc1;

            foreach (var entity in filter.Value)
            {
                var weapon = weaponPool.Get(entity);

                //Spawn bullet...
                var spawnEvent = eventWorld.Value.NewEntity();

                spawnPool.Value.Add(spawnEvent) = new SpawnRequest();
                positionPool.Value.Add(spawnEvent) = new Position { value = weapon.firePoint.position };
                rotationPool.Value.Add(spawnEvent) = new Rotation { value = weapon.firePoint.rotation };
                prefabPool.Value.Add(spawnEvent) = new Prefab { value = weapon.bulletPrefab };

                Debug.Log($"Pew {weapon.bulletPrefab.name}!");
                requestPool.Del(entity);
            }
        }
    }
}