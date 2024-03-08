using System;
using System.Collections.Generic;
using System.Globalization;
using Game.App;
using GameSystem;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_RealtimeReward
{
    public class TimeRewardSaveLoader : MonoBehaviour, IGameLoadListener
    {
        private HashSet<IRealtimeTimer> _realtimeTimers = new HashSet<IRealtimeTimer>();

        public void RegisterTimer(IRealtimeTimer realtimeTimer)
        {
            _realtimeTimers.Add(realtimeTimer);
            realtimeTimer.TimerStarted += OnTimerStarted;
        }

        public void UnregisterTimer(IRealtimeTimer realtimeTimer)
        {
            _realtimeTimers.Remove(realtimeTimer);
            realtimeTimer.TimerStarted -= OnTimerStarted;
        }
        
        public void OnLoadGame(GameFacade facade)
        {
            _realtimeTimers = new HashSet<IRealtimeTimer>(facade.GetServices<IRealtimeTimer>());

            foreach (var realtimeTimer in _realtimeTimers)
            {
                Load(realtimeTimer);
            }
        }

        private void OnTimerStarted(string id)
        {
            var now = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            PlayerPrefs.SetString(id, now);
            print("Save timer");
        }

        private void Load(IRealtimeTimer timer)
        {
            var offlineTime = CalculateOfflineTime(timer.SaveKey);
            timer.SyncrhonizeTime(offlineTime);
            
            print($"PAUSE SECONDS: {offlineTime}");
        }

        private float CalculateOfflineTime(string saveKey)
        {
            var savedTime = PlayerPrefs.GetString(saveKey);
            DateTime time = DateTime.Parse(savedTime, CultureInfo.InvariantCulture);

            var now = DateTime.Now;
            TimeSpan timeSpan = now - time;
            return (float)timeSpan.TotalSeconds;
        }

    }
}