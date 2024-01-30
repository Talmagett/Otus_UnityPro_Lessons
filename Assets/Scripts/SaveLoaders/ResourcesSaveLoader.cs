using System.Linq;
using GameEngine;
using SaveSystem;

namespace SaveLoaders
{
    public sealed class ResourcesSaveLoader : SaveLoader<ResourceData[], ResourceService>
    {
        protected override void SetupData(ResourceService resourceService, ResourceData[] data)
        {
            var resources = resourceService.GetResources().ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                if (resources[i].ID == data[i].id)
                    resources[i].Amount = data[i].amount;
            }
            resourceService.SetResources(resources);
        }

        protected override ResourceData[] ConvertToData(ResourceService resourceService)
        {
            var resources = resourceService.GetResources().ToArray();
            var resourcesData = new ResourceData[resources.Length];
            for (int i = 0; i < resources.Length; i++)
            {
                resourcesData[i].id = resources[i].ID;
                resourcesData[i].amount = resources[i].Amount;
            }

            return resourcesData;
        }
    }
}