using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Visual.Zombie
{
    public class ZombieAnimatorController
    {
        private const int Move = 1;
        private const int Death = 5;
        private static readonly int MainState = Animator.StringToHash("MainState");
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        private readonly Animator _animator;
        private readonly AtomicEvent _attackEvent;

        private readonly IAtomicValue<bool> _isDead;

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