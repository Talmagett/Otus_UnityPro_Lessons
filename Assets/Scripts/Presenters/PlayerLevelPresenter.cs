using System;
using Models;
using Views;

namespace Presenters
{
    public class PlayerLevelPresenter : IDisposable
    {
        private readonly PlayerExperienceView _playerExperienceView;
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerLevelView _playerLevelView;

        public PlayerLevelPresenter(PlayerLevel playerLevel, PlayerExperienceView playerExperienceView,
            PlayerLevelView playerLevelView)
        {
            _playerLevelView = playerLevelView;
            _playerLevel = playerLevel;
            _playerExperienceView = playerExperienceView;

            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _playerLevel.OnLevelUp += OnLevelChanged;

            _playerLevelView.AddOnLevelUpListener(_playerLevel.LevelUp);

            OnLevelChanged();
        }

        public void Dispose()
        {
            _playerLevelView.RemoveOnLevelUpListener(_playerLevel.LevelUp);
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        }

        private void OnExperienceChanged(int xp)
        {
            int requiredXp =_playerLevel.RequiredExperience;
            
            _playerExperienceView.SetFullExperienceBarActive(xp >= requiredXp);
            _playerExperienceView.SetExperienceFillAmount((float)xp / requiredXp);
            _playerExperienceView.SetExperienceText($"XP: {xp} / {requiredXp}");
            _playerLevelView.SetVisibleLevelUpButton(_playerLevel.CanLevelUp());
        }

        private void OnLevelChanged()
        {
            _playerLevelView.SetLevel($"Level: {_playerLevel.CurrentLevel}");
            OnExperienceChanged(_playerLevel.CurrentExperience);
        }
    }
}