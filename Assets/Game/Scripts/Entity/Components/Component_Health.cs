using System;
using Data.Variable;

namespace Entity.Components
{
    public class Component_Health : IComponent_Health, IDisposable
    {
        private readonly IAtomicVariable<int> _health;
        public event Action<int> OnHealthChanged;

        public Component_Health(IAtomicVariable<int> health)
        {
            _health = health;
            _health.ValueChanged += OnHealthChangedInvoke;
        }

        public void Dispose()
        {
            _health.ValueChanged -= OnHealthChangedInvoke;
        }

        public int GetHealth()
        {
            return _health.Value;
        }

        private void OnHealthChangedInvoke(int health)
        {
            OnHealthChanged?.Invoke(health);
        }
    }
}