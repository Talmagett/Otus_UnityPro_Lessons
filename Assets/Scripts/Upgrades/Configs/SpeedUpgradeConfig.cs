using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "SO/Upgrades/Create SpeedUpgradeConfig", fileName = "SpeedUpgradeConfig", order = 0)]
    public class SpeedUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new SpeedUpgrade(this);
        }
    }
}