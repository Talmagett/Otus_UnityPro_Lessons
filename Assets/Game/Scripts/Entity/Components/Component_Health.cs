using Data.Variable;

namespace Entity.Components
{
    public class Component_Health : IComponent_Health
    {
        private readonly IAtomicValue<int> _health;

        public Component_Health(IAtomicValue<int> health)
        {
            _health = health;
        }

        public int GetHealth()
        {
            return _health.Value;
        }
    }
}