using System;
using Models;
using UnityEngine;
using View;

namespace Presenter
{
    public class UserInfoPresenter:IDisposable
    {
        private readonly UserInfo _userInfo;
        private readonly UserInfoView _userInfoView;
        
        public UserInfoPresenter(UserInfo userInfo, UserInfoView userInfoView)
        {
            _userInfo = userInfo;
            _userInfoView = userInfoView;

            _userInfo.OnNameChanged += ChangeName;
            _userInfo.OnDescriptionChanged += ChangeDescription;
            _userInfo.OnIconChanged += ChangeIcon;
            
            
            ChangeName(_userInfo.Name);
            ChangeDescription(_userInfo.Description);
            ChangeIcon(_userInfo.Icon);
        }

        private void ChangeName(string name)
        {
            _userInfoView.SetName(name);
        }
        
        private void ChangeDescription(string description)
        {
            _userInfoView.SetDescription(description);
        }
        
        private void ChangeIcon(Sprite icon)
        {
            _userInfoView.SetIcon(icon);
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= ChangeName;
            _userInfo.OnDescriptionChanged -= ChangeDescription;
            _userInfo.OnIconChanged -= ChangeIcon;
        }
    }
}