using EcsEngine.Components.Life;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    internal sealed class BulletInstaller : EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new BulletTag());
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new MoveDirection { value = Vector3.forward });
            entity.AddData(new MoveSpeed { value = 5 });
            entity.AddData(new Damage { value = 3 });
            entity.AddData(new TransformView { value = transform });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}