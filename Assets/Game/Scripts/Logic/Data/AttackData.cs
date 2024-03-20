using System;
using Data.Event;
using Data.Variable;

namespace Logic.Data
{
    [Serializable]
    public class AttackData
    {
        public AtomicVariable<bool> CanAttack;
        public AtomicVariable<int> Damage;
        public AtomicEvent AttackRequest;
        public AtomicEvent AttackEvent;
    }
}