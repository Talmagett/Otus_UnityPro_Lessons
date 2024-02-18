using Data.Event;
using UnityEngine;

namespace Logic
{
    public class DestroyMechanics
    {
        private readonly IAtomicEvent _death;
        private readonly GameObject _gameObject;

        public DestroyMechanics(IAtomicEvent death, GameObject gameObject)
        {
            _death = death;
            _gameObject = gameObject;
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
            Object.Destroy(_gameObject);
        }
    }
}