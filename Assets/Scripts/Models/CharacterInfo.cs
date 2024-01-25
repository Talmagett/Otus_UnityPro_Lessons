using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Models
{
    public sealed class CharacterInfo
    {
        public CharacterInfo()
        {
        }

        public CharacterInfo(string userName, string description, Sprite icon)
        {
            Name = userName;
            Description = description;
            Icon = icon;
        }

        [ShowInInspector] [ReadOnly] public string Name { get; private set; }

        [ShowInInspector] [ReadOnly] public string Description { get; private set; }

        [ShowInInspector] [ReadOnly] public Sprite Icon { get; private set; }

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;

        [Button]
        public void ChangeName(string name)
        {
            Name = name;
            OnNameChanged?.Invoke(name);
        }

        [Button]
        public void ChangeDescription(string description)
        {
            Description = description;
            OnDescriptionChanged?.Invoke(description);
        }

        [Button]
        public void ChangeIcon(Sprite icon)
        {
            Icon = icon;
            OnIconChanged?.Invoke(icon);
        }
    }
}