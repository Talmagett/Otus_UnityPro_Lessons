using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic.Data
{
    [System.Serializable]
    public class RotateData
    {
        public AtomicVariable<bool> CanRotate;
        public AtomicEvent<Vector3> RotatedEvent;
    }
}