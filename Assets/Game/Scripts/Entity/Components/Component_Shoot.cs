using Data.Event;

namespace Entity.Components
{
    public class Component_Shoot : IComponent_Shoot
    {
        private readonly IAtomicAction _shot;
        public Component_Shoot(IAtomicAction shot)
        {
            _shot = shot;
        }

        public void Shoot()
        {
            _shot.Invoke();
        }
    }
}