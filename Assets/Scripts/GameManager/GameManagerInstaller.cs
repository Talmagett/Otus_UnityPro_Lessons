using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameManager
{
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private List<GameObject> listenersGameObjects = new();
        private GameManager _gameManager;
        
        private void OnValidate()
        {
            RemoveNotIGameListeners();
        }
        
        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void RemoveNotIGameListeners()
        {
            var cache = new List<GameObject>();
            foreach (var listener in listenersGameObjects)
                if (listener == null || !listener.TryGetComponent(out IGameListener _))
                    cache.Add(listener);

            if (cache.Count > 0)
                Debug.LogWarning("You are trying to add GameObject which has no IGameListener interface");

            foreach (var item in cache)
                listenersGameObjects.Remove(item);
        }

        private void Awake()
        {
            foreach (var listener in listenersGameObjects)
            {
                var listeners = listener.GetComponents<IGameListener>();
                _gameManager.AddListeners(listeners);
            }
        }
    }
}