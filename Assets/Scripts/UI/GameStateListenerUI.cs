using GameManager;
using UnityEngine;

namespace UI
{
    public class GameStateListenerUI : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private GameState activateOnState;
        public void OnGameStart()
        {
            gameObject.SetActive(activateOnState==GameState.Playing);
        }

        public void OnGameFinish()
        {
            gameObject.SetActive(activateOnState==GameState.Finished);
        }

        public void OnGamePause()
        {
            gameObject.SetActive(activateOnState==GameState.Paused);
        }

        public void OnGameResume()
        {
            gameObject.SetActive(activateOnState==GameState.Playing);
        }
    }
}