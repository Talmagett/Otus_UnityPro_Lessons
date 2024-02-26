using TurnSystem.Events.Effect;
using UnityEngine;

namespace Entities.Config
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Lesson19/Ability")]
    public sealed class Ability : ScriptableObject
    {
        [SerializeReference]
        public IEffect[] Effects;
    }
}