using System;
using System.Collections.Generic;
using System.Linq;
using View;

namespace Presenter
{
    public class CharacterInfoPresenter:IDisposable
    {
        private readonly CharacterInfo _characterInfo;
        private readonly CharacterStatFabric _characterStatFabric;
        private readonly List<CharacterStatPresenter> _presenters=new List<CharacterStatPresenter>(); 
        public CharacterInfoPresenter(CharacterInfo characterInfo, CharacterStatFabric characterStatFabric)
        {
            _characterInfo = characterInfo;
            _characterStatFabric = characterStatFabric;
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
            var characterStatView = _characterStatFabric.CreateStat(stat);
            var characterStatPresenter = new CharacterStatPresenter(stat, characterStatView);
            _presenters.Add(characterStatPresenter);
        }
        
        private void RemoveStat(CharacterStat stat)
        {
            var characterStatPresenter = _presenters.FirstOrDefault(t => t.StatName == stat.Name);
            if (characterStatPresenter == null)
                return;
            _characterStatFabric.DestroyStat(characterStatPresenter.CharacterStatView);
            _presenters.Remove(characterStatPresenter);
        }
    }
}