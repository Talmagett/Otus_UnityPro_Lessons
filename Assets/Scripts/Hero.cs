using System;
using Sample;
using Sirenix.OdinInspector;
using UnityEngine;

public class Hero : MonoBehaviour
{
        private PlayerStats _playerStats;

        private void Awake()
        {
                _playerStats = new PlayerStats();
        }

        [Button]
        public void AddStat(string name, int value)
        {
                _playerStats.AddStat(name,value);
        }
        
        [Button]
        public void GetStat(string name)
        {
                _playerStats.GetStat(name);
        }
        
        [Button]
        public void RemoveStat(string name)
        {
                _playerStats.RemoveStat(name);
        }
        
        [Button]
        public void GetStats()
        {
                foreach (var stat in _playerStats.GetStats())
                {
                        print($"{stat.Key}:{stat.Value}");
                }
        }
}