using UnityEngine;

namespace Lessons.Entities.Config
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "Lesson19/Hero")]
    public class Hero : ScriptableObject
    {
        [field:SerializeField] public int Health {get; private set;}
        [field:SerializeField] public int AttackDamage {get; private set;}
        [field:SerializeField] public Ability Ability {get; private set;}
    }
}