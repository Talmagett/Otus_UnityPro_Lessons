using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Models;
using Views;

namespace Presenters
{
    [UsedImplicitly]
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
                var characterStatView = _characterStatFactory.CreateStat();
                characterStatView.SetStatData($"{characterStat.Name} : {characterStat.Value}");
            }
        }

        public void Dispose()
        {
            _characterStatsInfo.OnStatAdded -= AddStat;
            _characterStatsInfo.OnStatRemoved -= RemoveStat;
        }

        private void AddStat(CharacterStat characterStat)
        {
            var characterStatView = _characterStatFactory.CreateStat();
            characterStatView.SetStatData($"{characterStat.Name} : {characterStat.Value}");
            
            var characterStatPresenter = new CharacterStatPresenter(characterStat, characterStatView);
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