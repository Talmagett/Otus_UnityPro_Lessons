using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public sealed class GameManager : MonoBehaviour
    {
        public GameState State { get; private set; } = GameState.Prepare;
        private readonly List<Listeners.IGameStateListener> _listeners = new();
        
        public void AddListener(Listeners.IGameStateListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(Listeners.IGameStateListener listener)
        {
            _listeners.Remove(listener);
        }

        public void StartGame()
        {
            State = GameState.Playing;
            foreach (var stateListener in _listeners)
            {
                if (stateListener is Listeners.IOnGameStarted onGameStarted)
                    onGameStarted.OnGameStarted();
            }
        }

        public void PauseGame()
        {
            State = GameState.Paused;
            foreach (var stateListener in _listeners)
            {
                if (stateListener is Listeners.IOnGamePaused onGameStarted)
                    onGameStarted.OnGamePaused();
            }
        }

        public void ResumeGame()
        {
            State = GameState.Playing;
            foreach (var stateListener in _listeners)
            {
                if (stateListener is Listeners.IOnGameResumed onGameStarted)
                    onGameStarted.OnGameResumed();
            }
        }

        public void FinishGame()
        {
            State = GameState.Finished;
            foreach (var stateListener in _listeners)
            {
                if (stateListener is Listeners.IOnGameFinished onGameStarted)
                    onGameStarted.OnGameFinished();
            }
            Debug.Log("Game over!");
        }

        public enum GameState
        {
            Prepare,
            Playing,
            Paused,
            Finished
        }
    }
}