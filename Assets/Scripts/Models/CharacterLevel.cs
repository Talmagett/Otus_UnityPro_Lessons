using System;
using Sirenix.OdinInspector;

namespace Models
{
    public sealed class CharacterLevel
    {
        public CharacterLevel(int level = 1)
        {
            CurrentLevel = level;
        }

        [ShowInInspector] [ReadOnly] public int CurrentLevel { get; private set; }

        [ShowInInspector] [ReadOnly] public int CurrentExperience { get; private set; }

        [ShowInInspector] [ReadOnly] public int RequiredExperience => 100 * (CurrentLevel + 1);

        public event Action OnLevelUp;
        public event Action<int> OnExperienceChanged;

        [Button]
        public void AddExperience(int range)
        {
            var xp = Math.Min(CurrentExperience + range, RequiredExperience);
            CurrentExperience = xp;
            OnExperienceChanged?.Invoke(xp);
        }

        [Button]
        public void LevelUp()
        {
            if (CanLevelUp())
            {
                CurrentExperience = 0;
                CurrentLevel++;
                OnLevelUp?.Invoke();
            }
        }

        public bool CanLevelUp()
        {
            return CurrentExperience == RequiredExperience;
        }
    }
}