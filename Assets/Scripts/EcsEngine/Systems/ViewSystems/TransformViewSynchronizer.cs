using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.ViewSystems
{
    internal sealed class TransformViewSynchronizer : IEcsPostRunSystem
    {
        private readonly EcsFilterInject<Inc<TransformView, Position>> filter;
        private readonly EcsPoolInject<Rotation> rotationPool;

        void IEcsPostRunSystem.PostRun(IEcsSystems systems)
        {
            var rotationPool = this.rotationPool.Value;

            foreach (var entity in filter.Value)
            {
                ref var transform = ref filter.Pools.Inc1.Get(entity);
                var position = filter.Pools.Inc2.Get(entity);

                transform.value.position = position.value;

                if (rotationPool.Has(entity))
                {
                    var rotation = rotationPool.Get(entity).value;
                    transform.value.rotation = rotation;
                }
            }
        }
    }
}