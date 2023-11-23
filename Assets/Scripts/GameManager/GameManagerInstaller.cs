using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private List<GameObject> listenersGameObjects = new();

        private void OnValidate()
        {
            var cache = new List<GameObject>();
            foreach (var listener in listenersGameObjects)
                if (listener == null || !listener.TryGetComponent(out IGameListener _))
                    cache.Add(listener);

            if (cache.Count > 0)
                Debug.LogWarning("You are trying to add GameObject which has no IGameListener interface");

            foreach (var item in cache) listenersGameObjects.Remove(item);
        }

        private void Awake()
        {
            foreach (var listener in listenersGameObjects)
            {
                var listeners = listener.GetComponents<IGameListener>();
                gameManager.AddListeners(listeners);
            }
        }

        private void OnDestroy()
        {
            gameManager.Clear();
        }
    }
}