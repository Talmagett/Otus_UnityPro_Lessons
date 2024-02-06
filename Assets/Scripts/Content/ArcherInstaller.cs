using EcsEngine.Components;
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
    public class ArcherInstaller : EntityInstaller
    {
        [SerializeField] private int health;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float attackDelay;
        [SerializeField] private float attackRange;

        [Space] [SerializeField] private Animator animator;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new Health { value = health });
            entity.AddData(new DamagableTag());
            entity.AddData(new MoveSpeed { value = moveSpeed });
            
            entity.AddData(new AttackRange{value = attackRange});
            
            entity.AddData(new TargetEntity());
            entity.AddData(new MoveToTargetTag());
            
            entity.AddData(new AnimatorView { value = animator });
            entity.AddData(new TransformView { value = transform });
            
            entity.AddData(new GameObjectView { value = gameObject });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}