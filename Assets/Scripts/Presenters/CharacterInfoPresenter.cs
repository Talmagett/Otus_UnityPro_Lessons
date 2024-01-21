using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Views;

namespace Presenters
{
    public class CharacterInfoPresenter : IDisposable
    {
        private readonly CharacterInfo _characterInfo;
        private readonly CharacterStatFactory _characterStatFactory;
        private readonly List<CharacterStatPresenter> _presenters = new();

        public CharacterInfoPresenter(CharacterInfo characterInfo, CharacterStatFactory characterStatFactory)
        {
            _characterInfo = characterInfo;
            _characterStatFactory = characterStatFactory;
            _characterInfo.OnStatAdded += AddStat;
            _characterInfo.OnStatRemoved += RemoveStat;
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= AddStat;
            _characterInfo.OnStatRemoved -= RemoveStat;
        }

        private void AddStat(CharacterStat stat)
        {
            var characterStatView = _characterStatFactory.CreateStat(stat);
            var characterStatPresenter = new CharacterStatPresenter(stat, characterStatView);
            _presenters.Add(characterStatPresenter);
        }

        private void RemoveStat(CharacterStat stat)
        {
            var characterStatPresenter = _presenters.FirstOrDefault(t => t.StatName == stat.Name);
            if (characterStatPresenter == null)
                return;
            _characterStatFactory.DestroyStat(characterStatPresenter.CharacterStatView);
            _presenters.Remove(characterStatPresenter);
        }
    }
}