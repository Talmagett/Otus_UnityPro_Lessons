using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class GamePlaySystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<DeathEvent, PlayerBaseTag>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                filter.Pools.Inc1.Del(entity);
                Time.timeScale = 0;
                Debug.Log("GameOver");
            }
        }
    }
}