using Data.Event;
using UnityEngine;

namespace Logic.Mechanics
{
    public class DisableColliderMechanics
    {
        private readonly Collider _collider;
        private readonly IAtomicEvent _death;

        public DisableColliderMechanics(IAtomicEvent death, Collider collider)
        {
            _death = death;
            _collider = collider;
        }

        public void OnEnable()
        {
            _death.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _death.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            _collider.enabled = false;
        }
    }
}