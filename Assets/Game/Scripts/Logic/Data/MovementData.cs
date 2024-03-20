using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic.Data
{
    [System.Serializable]
    public class MovementData
    {
        public AtomicVariable<bool> CanMove;
        
        public AtomicVariable<float> Speed;
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicEvent<Vector3> MovedEvent;
    }
}