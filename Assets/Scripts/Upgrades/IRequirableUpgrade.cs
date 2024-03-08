namespace Sample
{
    public interface IRequirableUpgrade
    {
        public void AddRequirements(params Upgrade[] requiredUpgrades);
    }
}