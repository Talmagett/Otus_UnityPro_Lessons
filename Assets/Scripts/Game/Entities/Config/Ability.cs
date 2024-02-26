using Game.TurnSystem.Events.Effect;
using UnityEngine;

namespace Game.Entities.Config
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Lesson19/Ability")]
    public sealed class Ability : ScriptableObject
    {
        [SerializeReference] public IEffect[] Effects;
    }
}