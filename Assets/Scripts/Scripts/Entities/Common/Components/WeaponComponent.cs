using Lessons.Entities.Config;
using Lessons.Utils;

namespace Lessons.Entities.Common.Components
{
    public sealed class WeaponComponent
    {
        public Ability Value => _weapon;
        
        private readonly AtomicVariable<Ability> _weapon;
        
        public WeaponComponent(AtomicVariable<Ability> weapon)
        {
            _weapon = weapon;
        }
    }
}