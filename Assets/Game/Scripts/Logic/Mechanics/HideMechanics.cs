using Data.Event;
using UnityEngine;

namespace Logic.Mechanics
{
    public class HideMechanics
    {
        private readonly IAtomicEvent _death;
        private readonly GameObject _gameObject;

        public HideMechanics(IAtomicEvent death, GameObject gameObject)
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
            _gameObject.gameObject.SetActive(false);
        }
    }
}