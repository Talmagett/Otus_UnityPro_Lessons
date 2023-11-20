using UnityEngine;

namespace GameManager
{
    [RequireComponent(typeof(GameManager))]

    public class GameManagerInstaller:MonoBehaviour
    {
        private void Awake()
        {
            var gameManager = this.GetComponent<GameManager>();
            var listeners = this.GetComponentsInChildren<Listeners.IGameStateListener>();
            
            foreach (var listener in listeners)
            {
                gameManager.AddListener(listener);
            }
        }
    }
}