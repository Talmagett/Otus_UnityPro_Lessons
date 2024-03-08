using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_RealtimeReward
{
    public class TimeRewardModule : MonoBehaviour, IGameElementGroup, IGameConstructElement, IGameServiceGroup
    {
        [SerializeField] private TimeRewardConfig _timeRewardConfig;
        
        [ShowInInspector]
        public readonly TimeReward _timeReward = new TimeReward();
        
        public IEnumerable<IGameElement> GetElements()
        {
            yield return _timeReward;
        }

        public IEnumerable<object> GetServices()
        {
            yield return _timeReward;
        }

        public void ConstructGame(GameContext context)
        {
            print("Construct TimeRewardModule");
            var moneyStorage = context.GetService<MoneyStorageDecorator>();
            _timeReward.Construct(_timeRewardConfig, moneyStorage);
            ServiceLocator.GetService<TimeRewardSaveLoader>().RegisterTimer(_timeReward);
        }
    }
}