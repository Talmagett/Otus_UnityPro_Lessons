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
    public class KnightInstaller : EntityInstaller
    {
        [SerializeField] private int health;
        [SerializeField] private float moveSpeed;

        [Space] [SerializeField] private int damage;

        [SerializeField] private float attackDelay;
        [SerializeField] private float attackRange;

        [Space] [SerializeField] private Animator animator;

        [SerializeField] private Renderer[] meshRenderers;
        [SerializeField] private ParticleSystem hitParticle;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new Health { value = health });
            entity.AddData(new DamagableTag());
            entity.AddData(new MoveSpeed { value = moveSpeed });

            entity.AddData(new AttackRange { value = attackRange });
            entity.AddData(new Cooldown { maxValue = attackDelay });

            entity.AddData(new MeleeWeapon());
            entity.AddData(new Damage { value = damage });
            entity.AddData(new TargetEntity());
            entity.AddData(new MoveToTargetTag());

            entity.AddData(new HitParticle { value = hitParticle });
            entity.AddData(new AnimatorView { value = animator });
            entity.AddData(new TransformView { value = transform });
            entity.AddData(new RendererView { values = meshRenderers });
            entity.AddData(new GameObjectView { value = gameObject });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}