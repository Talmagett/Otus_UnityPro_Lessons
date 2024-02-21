using Data.Event;

namespace Entity.Components
{
    public class Component_Damagable : IComponent_Damagable
    {
        private readonly IAtomicAction<int> _takeDamage;
        public Component_Damagable(IAtomicAction<int> takeDamage)
        {
            _takeDamage = takeDamage;
        }

        public void TakeDamage(int damage)
        {
            _takeDamage.Invoke(damage);
        }
    }
}