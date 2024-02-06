using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Life
{
    internal sealed class DeathRequestSystem : IEcsRunSystem
    {
        private EcsPoolInject<DeathEvent> eventPool;
        private EcsFilterInject<Inc<DeathRequest, GameObjectView>, Exc<Inactive>> filter;
        private EcsPoolInject<Inactive> tagPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                filter.Pools.Inc1.Del(entity);

                //TODO: переработать
                filter.Pools.Inc2.Get(entity).value.SetActive(false);
                tagPool.Value.Add(entity) = new Inactive();
                eventPool.Value.Add(entity) = new DeathEvent();
            }
        }
    }
}