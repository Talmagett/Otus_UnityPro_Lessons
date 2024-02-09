using EcsEngine.Components.Life;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class ArrowInstaller : EntityInstaller
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private int damage;

        [SerializeField] private ParticleSystem hitParticle;

        protected override void Install(Entity entity)
        {
            entity.AddData(new ArrowTag());
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new MoveDirection { value = transform.forward });
            entity.AddData(new MoveSpeed { value = moveSpeed });
            entity.AddData(new Damage { value = damage });

            entity.AddData(new HitParticle { value = hitParticle });
            entity.AddData(new TransformView { value = transform });
            entity.AddData(new GameObjectView { value = gameObject });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}