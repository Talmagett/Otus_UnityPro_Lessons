using System;
using Game.Gameplay.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DebugMoney : MonoBehaviour
{
        [SerializeField] private Text moneyText;
        [SerializeField] private MoneyStorage moneyStorage;
        
        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
                this.moneyStorage = moneyStorage;
                this.moneyStorage.OnMoneyChanged += UpdateDebugText;
                this.moneyStorage.SetupMoney(0);
        }

        private void OnDestroy()
        {
                this.moneyStorage.OnMoneyChanged -= UpdateDebugText;
        }

        private void UpdateDebugText(int amount)
        {
                moneyText.text = $"Money = {amount}";
        }
}