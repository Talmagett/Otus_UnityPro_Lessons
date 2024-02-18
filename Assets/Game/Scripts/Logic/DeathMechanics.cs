using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic
{
    public class DeathMechanics
    {
        private readonly IAtomicVariable<bool> _isDead;
        private readonly IAtomicEvent _death;

        public DeathMechanics(IAtomicVariable<bool> isDead, IAtomicEvent death)
        {
            _isDead = isDead;
            _death = death;
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
            if (_isDead.Value)
            {
                return;    
            }

            _isDead.Value = true;
            Debug.Log("Death");
        }
    }
}