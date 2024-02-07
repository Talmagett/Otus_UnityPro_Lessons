using System;
using EcsEngine;
using EcsEngine.Components;
using EcsEngine.Components.Physics;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    [RequireComponent(typeof(Entity))]
    public sealed class ArrowTriggerCollisionComponent : MonoBehaviour
    {
        private Entity entity;

        private void Awake()
        {
            entity = GetComponent<Entity>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Entity target)) return;
            if (target.HasData<ArrowTag>()) return;
            
            EcsAdmin.Instance.CreateEntity(EcsWorlds.Events)
                .Add(new CollisionEnterRequest())
                .Add(new ArrowTag())
                .Add(new SourceEntity { value = entity.Id })
                .Add(new TargetEntity { value = target.Id })
                .Add(new Position { value = other.ClosestPoint(transform.position)});
        }
    }
}