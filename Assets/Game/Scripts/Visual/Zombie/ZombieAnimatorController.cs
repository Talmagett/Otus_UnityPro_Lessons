using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Visual
{
    public class ZombieAnimatorController
    {
        private static readonly int MainState = Animator.StringToHash("MainState");
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");

        private const int Move = 1;
        private const int Death = 5;
        
        private readonly IAtomicValue<bool> _isDead;
        private readonly Animator _animator;
        private readonly AtomicEvent _attackEvent;

        public ZombieAnimatorController(
            IAtomicValue<bool> isDead,
            Animator animator,
            AtomicEvent attackEvent
            )
        {
            _isDead = isDead;
            _animator = animator;
            _attackEvent = attackEvent;
        }

        public void OnEnable()
        {
            _attackEvent.Subscribe(OnFireRequested);
        }

        public void OnDisable()
        {
            _attackEvent.Unsubscribe(OnFireRequested);
        }

        private void OnFireRequested()
        {
            _animator.SetTrigger(AttackTrigger);
        }

        public void Update()
        {
            _animator.SetInteger(MainState, GetAnimationValue());
        }

        private int GetAnimationValue()
        {
            return _isDead.Value ? Death : Move;
        }
    }
}