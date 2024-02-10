using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "SO/Upgrades/Create AttackUpgradeConfig", fileName = "AttackUpgradeConfig", order = 0)]
    public class AttackUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new AttackUpgrade(this);
        }
    }
}