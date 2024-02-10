using System.Linq;

namespace Sample
{
    public class DashStrikeUpgrade : Upgrade
    {
        private Upgrade[] _requiredUpgrades;
        public DashStrikeUpgrade(UpgradeConfig config, params Upgrade[] requiredUpgrades) : base(config)
        {
        }

        protected override bool CanUpgrade()
        {
            return _requiredUpgrades.All(upgrade => Level < upgrade.Level);
        }
        
        protected override void LevelUp(int level)
        {
        }
    }
}