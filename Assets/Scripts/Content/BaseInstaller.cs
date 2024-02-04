using EcsEngine.Components;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
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

        protected override void Install(Entity entity)
        {
            entity.AddData(new Position {value = this.spawnPoint.position});
            entity.AddData(new Rotation {value = this.transform.rotation});
            entity.AddData(new Health {value = health});
            entity.AddData(new DamagableTag());
            entity.AddData(new PlayerID{value = playerID});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}