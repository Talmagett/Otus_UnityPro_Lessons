using Sirenix.Utilities;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "SO/Upgrades/Create DashStrikeUpgradeConfig", fileName = "DashStrikeUpgradeConfig", order = 0)]
    public class DashStrikeUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new DashStrikeUpgrade(this);
        }
    }
}