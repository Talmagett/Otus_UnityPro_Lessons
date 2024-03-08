using System.Linq;
using Sample;
using UnityEngine;
using Zenject;

public class UpgradesInstaller : MonoBehaviour
{
    [SerializeField] private UpgradeCatalog catalog;

    [Inject]
    public void Construct(UpgradesManager upgradesManager)
    {
        var upgradesConfig = catalog.GetAllUpgradesConfig();
        var upgrades = new Upgrade[upgradesConfig.Length];
        for (var i = 0; i < upgradesConfig.Length; i++) upgrades[i] = upgradesConfig[i].InstantiateUpgrade();

        foreach (var config in upgradesConfig)
        {
            if (config.requiredUpgrades.Length == 0)
                continue;

            var targetUpgrade = upgrades.FirstOrDefault(t => t.Id == config.id);
            if (targetUpgrade is not IRequirableUpgrade requirableUpgrade)
                continue;
            var query = from firstItem in upgrades
                join secondItem in config.requiredUpgrades
                    on firstItem.Id equals secondItem.id
                select firstItem;

            requirableUpgrade.AddRequirements(query.ToArray());
        }

        upgradesManager.Setup(upgrades);
    }
}