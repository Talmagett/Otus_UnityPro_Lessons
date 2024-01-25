using System;
using Models;
using Views;

namespace Presenters
{
    public class CharacterLevelPresenter : IDisposable
    {
        private readonly CharacterExperienceView _characterExperienceView;
        private readonly CharacterLevel _characterLevel;
        private readonly CharacterLevelView _characterLevelView;

        public CharacterLevelPresenter(CharacterLevel characterLevel, CharacterExperienceView characterExperienceView,
            CharacterLevelView characterLevelView)
        {
            _characterLevelView = characterLevelView;
            _characterLevel = characterLevel;
            _characterExperienceView = characterExperienceView;

            _characterLevel.OnExperienceChanged += OnExperienceChanged;
            _characterLevel.OnLevelUp += OnLevelChanged;

            _characterLevelView.AddOnLevelUpListener(_characterLevel.LevelUp);

            OnLevelChanged();
        }

        public void Dispose()
        {
            _characterLevelView.RemoveOnLevelUpListener(_characterLevel.LevelUp);
            _characterLevel.OnExperienceChanged -= OnExperienceChanged;
        }

        private void OnExperienceChanged(int xp)
        {
            var requiredXp = _characterLevel.RequiredExperience;
            _characterExperienceView.SetExperience($"XP: {xp} / {requiredXp}", (float)xp / requiredXp,
                xp >= requiredXp);
            _characterLevelView.SetVisibleLevelUpButton(_characterLevel.CanLevelUp());
        }

        private void OnLevelChanged()
        {
            _characterLevelView.SetLevel($"Level: {_characterLevel.CurrentLevel}");
            OnExperienceChanged(_characterLevel.CurrentExperience);
        }
    }
}