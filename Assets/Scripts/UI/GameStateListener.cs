using GameManager;
using UnityEngine;
using Zenject;

namespace UI
{
    public class GameStateListener : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private GameState activateOnState;

        private GameManager.GameManager _gameManager;

        [Inject]
        public void Construct(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.AddListener(this);
        }
        
        public void OnGameStart()
        {
            gameObject.SetActive(activateOnState == GameState.Playing);
        }

        public void OnGameFinish()
        {
            gameObject.SetActive(activateOnState == GameState.Finished);
        }

        public void OnGamePause()
        {
            gameObject.SetActive(activateOnState == GameState.Paused);
        }

        public void OnGameResume()
        {
            gameObject.SetActive(activateOnState == GameState.Playing);
        }
    }
}