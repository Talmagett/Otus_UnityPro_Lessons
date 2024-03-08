using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Visual.Character
{
    public class CharacterAnimatorController
    {
        private const int Idle = 0;
        private const int Move = 1;
        private const int Death = 2;
        
        private static readonly int MainState = Animator.StringToHash("MainState");
        private static readonly int ShootTrigger = Animator.StringToHash("Shoot");
        private static readonly int HitTrigger = Animator.StringToHash("Hit");
        
        private readonly Animator _animator;
        private readonly AtomicEvent _fireRequest;
        private readonly IAtomicValue<bool> _isDead;
        private readonly IAtomicEvent<int> _hit;
        private readonly AtomicEvent<Vector3> _onMoved;
        private Vector3 _moveDirection;

        public CharacterAnimatorController(
            AtomicEvent<Vector3> onMoved,
            IAtomicValue<bool> isDead,
            AtomicEvent<int> hit,
            Animator animator,
            AtomicEvent fireRequest
        )
        {
            _onMoved = onMoved;
            _isDead = isDead;
            _hit = hit;
            _animator = animator;
            _fireRequest = fireRequest;
        }

        public void OnEnable()
        {
            _fireRequest.Subscribe(OnFireRequested);
            _onMoved.Subscribe(OnMoved);
            _hit.Subscribe(OnHit);
        }


        public void OnDisable()
        {
            _fireRequest.Unsubscribe(OnFireRequested);
            _onMoved.Unsubscribe(OnMoved);
            _hit.Unsubscribe(OnHit);
        }

        private void OnHit(int damage)
        {
            _animator.SetTrigger(HitTrigger);
        }
        
        private void OnMoved(Vector3 direction)
        {
            _moveDirection = direction;
        }
        
        private void OnFireRequested()
        {
            _animator.SetTrigger(ShootTrigger);
        }

        public void Update()
        {
            _animator.SetInteger(MainState, GetAnimationValue());
        }

        private int GetAnimationValue()
        {
            if (_isDead.Value) return Death;
            
            if (_moveDirection != Vector3.zero)
            {
                return Move;
            }

            return Idle;
        }
    }
}