using Entities;
using UnityEngine;

namespace Lessons.TurnSystem.Events
{
    public readonly struct ApplyDirectionEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ApplyDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}