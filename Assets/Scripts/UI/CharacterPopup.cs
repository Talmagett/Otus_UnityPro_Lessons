using System;
using Presenter;
using UnityEngine;
using View;

namespace UI
{
    public class CharacterPopup:MonoBehaviour
    {
        [SerializeField] private PlayerExperienceView playerExperienceView;
        [SerializeField] private PlayerLevelView playerLevelView;
        [SerializeField] private UserInfoView userInfoView;
        
        [Space]
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private CharacterInfo characterInfo;
        [SerializeField] private CharacterStat characterStat;
        [SerializeField] private UserInfo userInfo;
        
        private PlayerLevelPresenter _playerLevelPresenter;
        private UserInfoPresenter _userInfoPresenter;
        private void Awake()
        {
            _playerLevelPresenter = new PlayerLevelPresenter(playerLevel,playerExperienceView,playerLevelView);
            _userInfoPresenter = new UserInfoPresenter(userInfo,userInfoView);
        }
    }
}