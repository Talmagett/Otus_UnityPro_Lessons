using Modules.Entities.Scripts;
using UnityEngine;

namespace TurnSystem.Events
{
    public readonly struct ForceDirectionEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ForceDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}