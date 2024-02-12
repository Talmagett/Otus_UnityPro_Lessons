using Sample;
using UnityEngine;
using Zenject;

public class DebugUpgrade : MonoBehaviour
{
    [SerializeField] private UpgradesManager upgradesManager;
    
    [Inject]
    public void Construct(UpgradesManager upgradesManager)
    {
        this.upgradesManager = upgradesManager;
    }
}