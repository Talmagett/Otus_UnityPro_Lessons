using EcsEngine.Components.Attack;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class CooldownSystem: IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Cooldown>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;
            var cooldownPool = filter.Pools.Inc1;

            foreach (var entity in filter.Value)
            {
                ref var cooldown = ref cooldownPool.Get(entity);

                if (cooldown.canUse)
                    continue;

                cooldown.value -= deltaTime;
            }
        }
    }
}