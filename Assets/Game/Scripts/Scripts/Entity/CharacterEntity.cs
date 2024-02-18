using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Lessons.Lesson16_AtomicComponents.Entity
{
    public class CharacterEntity : Entity
    {
        [SerializeField] private Character _character;

        private void Awake()
        {
            Add(new MoveComponent(_character.Moved));
        }
    }
}