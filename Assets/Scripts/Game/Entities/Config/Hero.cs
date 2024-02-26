using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Entities.Config
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "Lesson19/Hero")]
    public class Hero : ScriptableObject
    {
        [field:SerializeField] public string Name {get; private set;}
        [field:SerializeField,PreviewField(height: 50,ObjectFieldAlignment.Left)] public Sprite Icon {get; private set;}
        [field:SerializeField] public int Health {get; private set;}
        [field:SerializeField] public int AttackDamage {get; private set;}
        [field:SerializeField] public Ability Ability {get; private set;}
    }
}