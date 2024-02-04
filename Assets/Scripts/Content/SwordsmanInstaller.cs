using EcsEngine.Components.Life;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using EcsEngine.Components.Views;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class SwordsmanInstaller : EntityInstaller
    {
        [SerializeField] private int health;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float attackDelay;
        [SerializeField] private float attackRange;
        
        [Space]
        [SerializeField]
        private Animator animator;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Position {value = this.transform.position});
            entity.AddData(new Rotation {value = this.transform.rotation});
            entity.AddData(new Health {value = health});
            entity.AddData(new DamagableTag());
            entity.AddData(new MoveSpeed{value = moveSpeed});
            entity.AddData(new MoveDirection{value = transform.forward});
            
            entity.AddData(new AnimatorView {value = this.animator});
            entity.AddData(new TransformView {value = this.transform});
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}