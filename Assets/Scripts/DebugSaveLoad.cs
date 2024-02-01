using SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class DebugSaveLoad : MonoBehaviour
{
        private SaveLoadManager _saveLoadManager;

        [Inject]
        public void Construct(SaveLoadManager saveLoadManager)
        {
                _saveLoadManager = saveLoadManager;
        }
        
        [Button]
        public void Save()
        {
                _saveLoadManager.Save();
        }
        
        [Button]
        public void Load()
        {
                _saveLoadManager.Load();
        }
}