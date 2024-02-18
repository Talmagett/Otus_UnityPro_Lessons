namespace Lessons.Lesson14_ModuleMechanics
{
    public class CanMoveMechanics
    {
        private readonly IAtomicVariable<bool> _canMove;
        private readonly IAtomicValue<bool> _isDead;

        public CanMoveMechanics(IAtomicVariable<bool> canMove, IAtomicValue<bool> isDead)
        {
            _canMove = canMove;
            _isDead = isDead;
        }

        public void Update()
        {
            _canMove.Value = CanMove(); 
        }

        private bool CanMove()
        {
            return !_isDead.Value;
        }
    }
}