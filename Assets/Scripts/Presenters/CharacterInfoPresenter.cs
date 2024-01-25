using System;
using UnityEngine;
using Views;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
    public class CharacterInfoPresenter : IDisposable
    {
        private readonly CharacterInfo _characterInfo;
        private readonly CharacterInfoView _characterInfoView;

        public CharacterInfoPresenter(CharacterInfo characterInfo, CharacterInfoView characterInfoView)
        {
            _characterInfo = characterInfo;
            _characterInfoView = characterInfoView;

            _characterInfo.OnNameChanged += ChangeName;
            _characterInfo.OnDescriptionChanged += ChangeDescription;
            _characterInfo.OnIconChanged += ChangeIcon;


            ChangeName(_characterInfo.Name);
            ChangeDescription(_characterInfo.Description);
            ChangeIcon(_characterInfo.Icon);
        }

        public void Dispose()
        {
            _characterInfo.OnNameChanged -= ChangeName;
            _characterInfo.OnDescriptionChanged -= ChangeDescription;
            _characterInfo.OnIconChanged -= ChangeIcon;
        }

        private void ChangeName(string name)
        {
            _characterInfoView.SetName(name);
        }

        private void ChangeDescription(string description)
        {
            _characterInfoView.SetDescription(description);
        }

        private void ChangeIcon(Sprite icon)
        {
            _characterInfoView.SetIcon(icon);
        }
    }
}