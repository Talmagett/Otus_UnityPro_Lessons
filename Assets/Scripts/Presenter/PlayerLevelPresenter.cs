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

            _playerLevel.OnExperienceChanged += UpdateExperienceView;
            _playerLevel.OnLevelUp += UpdateLevelView;
            UpdateLevelView();
        }

        private void UpdateExperienceView(int xp)
        {
            _playerExperienceView.SetExperience(xp,_playerLevel.RequiredExperience);
        }

        private void UpdateLevelView()
        {
            _playerLevelView.SetLevel(_playerLevel.CurrentLevel);
            _playerExperienceView.SetExperience(_playerLevel.CurrentExperience,_playerLevel.RequiredExperience);
        }
        
        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= UpdateExperienceView;
        }
    }
}