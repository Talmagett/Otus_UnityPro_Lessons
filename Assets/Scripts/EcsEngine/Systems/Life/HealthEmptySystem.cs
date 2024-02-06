using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Life
{
    internal sealed class HealthEmptySystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<DeathRequest> deathPool;
        private readonly EcsFilterInject<Inc<Health>, Exc<DeathRequest, Inactive>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var health = filter.Pools.Inc1.Get(entity);
                if (health.value <= 0) deathPool.Value.Add(entity) = new DeathRequest();
            }
        }
    }
}