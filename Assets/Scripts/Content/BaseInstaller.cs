using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class BaseInstaller : EntityInstaller
    {
        [SerializeField] private int health;
        [SerializeField] private int playerID;
        
        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private Entity archerPrefab;
        
        [SerializeField]
        private Entity swordmanPrefab;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new Health {value = health});
            entity.AddData(new DamagableTag());
            entity.AddData(new PlayerTag{ID = playerID});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}