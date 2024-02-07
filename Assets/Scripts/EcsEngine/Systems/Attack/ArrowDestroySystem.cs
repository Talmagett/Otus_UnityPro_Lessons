using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    internal sealed class ArrowDestroySystem : IEcsRunSystem
    {
        private EcsCustomInject<EntityManager> entityManager;
        private EcsFilterInject<Inc<ArrowTag, Inactive>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                Debug.Log("DESTROYED");
                entityManager.Value.Destroy(entity);
            }
        }
    }
}