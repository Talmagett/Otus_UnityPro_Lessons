using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Views;

namespace Presenters
{
    public class CharacterStatsInfoPresenter : IDisposable
    {
        private readonly CharacterStatFactory _characterStatFactory;
        private readonly CharacterStatsInfo _characterStatsInfo;
        private readonly List<CharacterStatPresenter> _presenters = new();

        public CharacterStatsInfoPresenter(CharacterStatsInfo characterStatsInfo,
            CharacterStatFactory characterStatFactory)
        {
            _characterStatsInfo = characterStatsInfo;
            _characterStatFactory = characterStatFactory;
            _characterStatFactory.ClearStats();

            _characterStatsInfo.OnStatAdded += AddStat;
            _characterStatsInfo.OnStatRemoved += RemoveStat;
            foreach (var characterStat in characterStatsInfo.GetStats())
            {
                _characterStatFactory.CreateStat(characterStat);
            }
        }

        public void Dispose()
        {
            _characterStatsInfo.OnStatAdded -= AddStat;
            _characterStatsInfo.OnStatRemoved -= RemoveStat;
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