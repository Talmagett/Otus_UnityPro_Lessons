using System;
using Models;
using View;

namespace Presenter
{
    public class CharacterStatPresenter : IDisposable
    {
        private readonly CharacterStat _characterStat;
        public CharacterStatView CharacterStatView { get; private set; }

        public string StatName => _characterStat.Name;
        public CharacterStatPresenter(CharacterStat characterStat, CharacterStatView characterStatView)
        {
            _characterStat = characterStat;
            CharacterStatView = characterStatView;
            _characterStat.OnValueChanged += UpdateValue;
        }

        public void Dispose()
        {
            _characterStat.OnValueChanged -= UpdateValue;
        }
        
        private void UpdateValue(int newValue)
        {
            CharacterStatView.SetStatData(_characterStat.Name,newValue);
        }
    }
}