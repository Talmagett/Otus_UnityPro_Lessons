using Game.Gameplay.Player;
using Sample;
using UnityEngine;
using Zenject;

public class DebugMoney : MonoBehaviour
{
        [SerializeField] private MoneyStorage moneyStorage;
        
        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
                this.moneyStorage = moneyStorage;
        }
}