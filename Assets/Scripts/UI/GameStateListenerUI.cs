using System;
using GameManager;
using UnityEngine;

namespace UI
{
    public class GameStateListenerUI : MonoBehaviour, IGameStartListener, IGameFinishListener, IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject resumeButton;
        [SerializeField] private GameObject gameFinish;
        
        public void OnGameStart()
        {
            startButton.SetActive(false);
            pauseButton.SetActive(true);
        }

        public void OnGameFinish()
        {
            pauseButton.SetActive(false);
            gameFinish.SetActive(true);
        }

        public void OnGamePause()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }

        public void OnGameResume()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
    }
}