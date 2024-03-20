using Data.Event;
using Data.Variable;
using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.LifeMechanics
{
    public class DeathMechanics
    {
        private readonly LifeData _lifeData;

        public DeathMechanics(LifeData lifeData)
        {
            _lifeData = lifeData;
        }

        public void OnEnable()
        {
            _lifeData.DeathEvent.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _lifeData.DeathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            if (_lifeData.IsDead.Value) return;

            _lifeData.IsDead.Value = true;
            Debug.Log("Death");
        }
    }
}