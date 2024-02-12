using System.Linq;

namespace Sample
{
    public class DashStrikeUpgrade : Upgrade
    {
        private Upgrade[] _requiredUpgrades;
        public DashStrikeUpgrade(UpgradeConfig config) : base(config)
        {
        }

        public void AddRequirements(params Upgrade[] requiredUpgrades)
        {
            _requiredUpgrades = requiredUpgrades;
        }
        
        public override bool CanUpgrade()
        {
            return _requiredUpgrades.All(upgrade => Level < upgrade.Level);
        }
        
        protected override void LevelUp(int level)
        {
        }
    }
}