using UnityEngine;

namespace Game.Entities.Common.Components
{
    public sealed class TransformComponent
    {
        public TransformComponent(Transform transform)
        {
            Value = transform;
        }

        public Transform Value { get; }
    }
}