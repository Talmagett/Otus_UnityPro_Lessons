using EcsEngine.Components.Life;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    public class MaterialViewSynchronizer : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<RendererView, MaterialView, Init>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var rendererPool = filter.Pools.Inc1;
            var materialPool = filter.Pools.Inc2;

            foreach (var entity in filter.Value)
            {
                Debug.Log($"{entity} was inited");
                ref var rendererView = ref rendererPool.Get(entity);
                var materialView = materialPool.Get(entity);
                foreach (var renderer in rendererView.values) renderer.material = materialView.value;
            }
        }
    }
}