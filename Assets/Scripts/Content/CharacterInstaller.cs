using EcsEngine.Components.Attack;
using EcsEngine.Components.Life;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public sealed class CharacterInstaller : EntityInstaller
    {
        [SerializeField] private Transform firePoint;

        [SerializeField] private Entity bulletPrefab;

        [SerializeField] private Animator animator;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new MoveDirection { value = Vector3.forward });
            entity.AddData(new MoveSpeed { value = 5 });
            entity.AddData(new Health { value = 5 });
            entity.AddData(new DamagableTag());

            entity.AddData(new BulletWeapon
            {
                firePoint = firePoint,
                bulletPrefab = bulletPrefab
            });


            entity.AddData(new AnimatorView { value = animator });
            entity.AddData(new TransformView { value = transform });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}