using Lessons.Lesson14_ModuleMechanics;
using Lessons.Lesson15_VisualMechanics;
using UnityEngine;

namespace Lessons.Lesson16_AtomicComponents.Presenters
{
    public class CharacterPresenter : MonoBehaviour, IMoveable
    {
        [SerializeField] private Character _character;

        public void Move(Vector3 moveDirection)
        {
            _character.Moved.Invoke(moveDirection);
        }
    }
}