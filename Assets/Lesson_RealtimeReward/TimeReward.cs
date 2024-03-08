using System;
using Elementary;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_RealtimeReward
{
    public class TimeReward : IRealtimeTimer, IGameStartElement
    {
        public event Action<string> TimerStarted;

        public string SaveKey => nameof(TimeReward);

        private TimeRewardConfig _timeRewardConfig;
        private MoneyStorageDecorator _moneyStorage;

        [ShowInInspector]
        private Countdown _timer = new Countdown();

        public void Construct(TimeRewardConfig timeRewardConfig, MoneyStorageDecorator moneyStorage)
        {
            _timeRewardConfig = timeRewardConfig;
            _moneyStorage = moneyStorage;
            _timer.Duration = _timeRewardConfig.Duration;
            _timer.RemainingTime = _timeRewardConfig.Duration;
        }
        
        public void StartGame()
        {
            PlayTimer();
        }
        
        private void PlayTimer()
        {
            if (_timer.Progress == 0f)
            {
                Debug.Log("Timer started");
                TimerStarted?.Invoke(SaveKey);
            }
            
            _timer.Play();
        }
        
        public void SyncrhonizeTime(float time)
        {
            _timer.RemainingTime -= time;
        }
        
        [Button]
        private void ReceiveReward()
        {
            if (CanReceiveReward())
            {
                Debug.Log("You received reward");
                _moneyStorage.EarnMoneySimple(_timeRewardConfig.MoneyReward);
                _timer.ResetTime();
                PlayTimer();
            }
            else
            {
                Debug.Log("You can't receive reward");
            }
        }

        private bool CanReceiveReward()
        {
            return _timer.Progress >= 1f;
        }
    }
}
