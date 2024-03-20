using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.LifeMechanics
{
    public class TakeDamageMechanics
    {
        private readonly LifeData _lifeData;

        public TakeDamageMechanics(LifeData lifeData)
        {
            _lifeData = lifeData;
        }

        public void OnEnable()
        {
            _lifeData.TakeDamage.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _lifeData.TakeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            var hitPoint = _lifeData.HitPoints.Value - damage;
            _lifeData.HitPoints.Value = Mathf.Max(0, hitPoint);

            if (_lifeData.HitPoints.Value == 0) _lifeData.DeathEvent?.Invoke();
        }
    }
}