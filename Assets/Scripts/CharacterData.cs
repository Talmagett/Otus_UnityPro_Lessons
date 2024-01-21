using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "SO/Create Character")]
public class CharacterData : ScriptableObject
{
    [field: SerializeField] public string UserName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public StatData[] Stats { get; private set; }

    [Serializable]
    [InlineProperty]
    public class StatData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Value { get; private set; }
    }
}