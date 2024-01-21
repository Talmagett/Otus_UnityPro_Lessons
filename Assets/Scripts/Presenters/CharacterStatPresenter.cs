using System;
using Models;
using Views;

namespace Presenters
{
    public class CharacterStatPresenter : IDisposable
    {
        private readonly CharacterStat _characterStat;

        public CharacterStatPresenter(CharacterStat characterStat, CharacterStatView characterStatView)
        {
            _characterStat = characterStat;
            CharacterStatView = characterStatView;
            _characterStat.OnValueChanged += UpdateValue;
        }

        public CharacterStatView CharacterStatView { get; }

        public string StatName => _characterStat.Name;

        public void Dispose()
        {
            _characterStat.OnValueChanged -= UpdateValue;
        }

        private void UpdateValue(int newValue)
        {
            CharacterStatView.SetStatData($"{_characterStat.Name} : {newValue}");
        }
    }
}