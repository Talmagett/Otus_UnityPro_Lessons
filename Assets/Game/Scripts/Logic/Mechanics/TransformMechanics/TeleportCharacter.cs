using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class TeleportCharacter : MonoBehaviour
    {
        public AtomicEvent<Vector3> Teleported;
        public AtomicVariable<float> Speed;

        private TeleportMechanics _teleportMechanics;

        private void Awake()
        {
            _teleportMechanics = new TeleportMechanics(Speed, Teleported, transform);
        }

        private void OnEnable()
        {
            _teleportMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _teleportMechanics.OnDisable();
        }
    }
}