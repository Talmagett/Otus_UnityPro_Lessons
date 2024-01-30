using GameEngine;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private ResourceService resourceService;

    public override void InstallBindings()
    {
        unitManager.SetupUnits(FindObjectsOfType<Unit>());
        resourceService.SetResources(FindObjectsOfType<Resource>());
    }
}