using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    internal sealed class DeathRequestSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<DeathRequest,TransformView>, Exc<Inactive>> filter;
        
        private EcsPoolInject<DeathEvent> eventPool;
        private EcsPoolInject<Inactive> tagPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int entity in this.filter.Value)
            {
                this.filter.Pools.Inc1.Del(entity);
                
                //TODO: переработать
                this.filter.Pools.Inc2.Get(entity).value.gameObject.SetActive(false);
                this.tagPool.Value.Add(entity) = new Inactive();
                this.eventPool.Value.Add(entity) = new DeathEvent();
            }
        }
    }
}