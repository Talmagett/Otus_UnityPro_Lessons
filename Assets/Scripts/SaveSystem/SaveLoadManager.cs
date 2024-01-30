using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        private GameRepository _repository;
        private GameContext _gameContext;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository, GameContext gameContext)
        {
            _saveLoaders = saveLoaders;
            _repository = repository;
            _gameContext = gameContext;
        }

        [Button]
        public void Load()
        {
            _repository.LoadState();
            foreach (var saveLoader in _saveLoaders) saveLoader.LoadGame(_repository, _gameContext);
        }

        [Button]
        public void Save()
        {
            foreach (var saveLoader in _saveLoaders) saveLoader.SaveGame(_repository, _gameContext);

            _repository.SaveState();
        }

        //TODO: TIMER

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}