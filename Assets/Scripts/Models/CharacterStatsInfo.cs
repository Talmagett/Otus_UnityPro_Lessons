using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Models
{
    public sealed class CharacterStatsInfo
    {
        [ShowInInspector] private readonly HashSet<CharacterStat> _stats = new();

        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;

        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (_stats.Add(stat)) OnStatAdded?.Invoke(stat);
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (_stats.Remove(stat)) OnStatRemoved?.Invoke(stat);
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in _stats)
                if (stat.Name == name)
                    return stat;

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return _stats.ToArray();
        }
    }
}