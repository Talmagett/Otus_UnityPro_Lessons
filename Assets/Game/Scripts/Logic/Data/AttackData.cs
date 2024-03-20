using Data.Event;
using Data.Variable;

namespace Logic.Data
{
    [System.Serializable]
    public class AttackData
    {
        public AtomicVariable<bool> CanAttack;
        public AtomicVariable<int> Damage;
        public AtomicEvent AttackRequest;
        public AtomicEvent AttackEvent;
    }
}