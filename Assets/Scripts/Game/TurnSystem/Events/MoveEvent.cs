using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.TurnSystem.Events
{
    public readonly struct MoveEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Coordinates;
        public readonly bool IsForced;

        public MoveEvent(IEntity entity, Vector2Int coordinates, bool isForced = false)
        {
            Entity = entity;
            Coordinates = coordinates;
            IsForced = isForced;
        }
    }
}