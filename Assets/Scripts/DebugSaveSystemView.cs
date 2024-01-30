using SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class DebugSaveSystemView : MonoBehaviour
{
    private GameRepository _gameRepository;

    [Inject]
    public void Construct(GameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [Button]
    public void SaveGame()
    {
        _gameRepository.SaveState();
    }

    [Button]
    public void LoadGame()
    {
        _gameRepository.LoadState();
    }
}