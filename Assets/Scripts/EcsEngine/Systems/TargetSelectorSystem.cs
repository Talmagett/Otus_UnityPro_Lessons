using System.Linq;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class TargetSelectorSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<DamagableTag, PlayerID, Position>> filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var entityTag = filter.Pools.Inc2.Get(entity).value;
                var enemies = filter.Pools.Inc2.GetRawDenseItems().Where(t => t.value != entityTag);
                //filter.Pools.Inc3.GetRawDenseItems().Where(t=>).OrderBy(t=>t.value)
            }
        }
    }
}