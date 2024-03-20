using Data.Event;
using Data.Variable;

namespace Logic.Data
{
    [System.Serializable]
    public class LifeData
    {
        public AtomicVariable<int> HitPoints;
        public AtomicEvent<int> TakeDamage;

        public AtomicVariable<bool> IsDead;
        public AtomicEvent DeathEvent;
    }
}