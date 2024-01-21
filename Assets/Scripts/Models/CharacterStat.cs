using System;
using Sirenix.OdinInspector;

namespace Models
{
    public sealed class CharacterStat
    {
        public CharacterStat(string name, int value)
        {
            Name = name;
            Value = value;
        }

        [ShowInInspector] [ReadOnly] public string Name { get; private set; }

        [ShowInInspector] [ReadOnly] public int Value { get; private set; }

        public event Action<int> OnValueChanged;

        [Button]
        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}