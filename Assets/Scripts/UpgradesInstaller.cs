using System.Linq;
using Sample;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

public class UpgradesInstaller : MonoBehaviour
{
        [SerializeField] private UpgradeConfig[] upgradeConfigs;
        
        [Inject]
        public void Construct(UpgradesManager upgradesManager)
        {
                var upgrades = new Upgrade[upgradeConfigs.Length];
                for (int i = 0; i < upgradeConfigs.Length; i++)
                {
                        upgrades[i]=upgradeConfigs[i].InstantiateUpgrade();
                }
                upgradesManager.Setup(upgrades);       
        }
}