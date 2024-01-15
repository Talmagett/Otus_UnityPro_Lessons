using System;
using View;

namespace Presenter
{
    public class PlayerLevelPresenter:IDisposable
    {
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerExperienceView _playerExperienceView;
        private readonly PlayerLevelView _playerLevelView;
        
        public PlayerLevelPresenter(PlayerLevel playerLevel,PlayerExperienceView playerExperienceView, PlayerLevelView playerLevelView)
        {
            _playerLevelView = playerLevelView;
            _playerLevel = playerLevel;
            _playerExperienceView = playerExperienceView;

            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _playerLevel.OnLevelUp += OnLevelChanged;

            _playerLevelView.AddOnLevelUpListener(_playerLevel.LevelUp);
            
            OnLevelChanged();
        }

        private void OnExperienceChanged(int xp)
        {
            _playerExperienceView.SetExperience(xp,_playerLevel.RequiredExperience);
            _playerLevelView.SetVisibleLevelUpButton(_playerLevel.CanLevelUp());
        }

        private void OnLevelChanged()
        {
            _playerLevelView.SetLevel(_playerLevel.CurrentLevel);
            OnExperienceChanged(_playerLevel.CurrentExperience);
        }
        
        public void Dispose()
        {
            _playerLevelView.RemoveOnLevelUpListener(_playerLevel.LevelUp);
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        }
    }
}