using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public enum GameState
    {
        Prepare,
        Playing,
        Paused,
        Finished
    }

    public sealed class GameManager : MonoBehaviour
    {
        public GameState State { get; private set; } = GameState.Prepare;

        private readonly List<IGameListener> _gameListeners = new();

        private readonly List<IGameUpdateListener> _gameUpdateListeners = new();
        private readonly List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();
        private readonly List<IGameLateUpdateListener> _gameLateUpdateListeners = new();

        public void AddListener(IGameListener listener)
        {
            _gameListeners.Add(listener);
            if(listener is IGameUpdateListener updateListener)
                _gameUpdateListeners.Add(updateListener);
            if(listener is IGameFixedUpdateListener fixedUpdateListener)
                _gameFixedUpdateListeners.Add(fixedUpdateListener);
            if(listener is IGameLateUpdateListener lateUpdateListener)
                _gameLateUpdateListeners.Add(lateUpdateListener);
        }

        public void AddListeners(IGameListener[] listeners)
        {
            foreach (var listener in listeners)
            {
                AddListener(listener);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            _gameListeners.Remove(listener);
            if(listener is IGameUpdateListener updateListener)
                _gameUpdateListeners.Remove(updateListener);
            if(listener is IGameFixedUpdateListener fixedUpdateListener)
                _gameFixedUpdateListeners.Remove(fixedUpdateListener);
            if(listener is IGameLateUpdateListener lateUpdateListener)
                _gameLateUpdateListeners.Remove(lateUpdateListener);
        }
        
        public void RemoveListeners(IGameListener[] listeners)
        {
            foreach (var listener in listeners)
            {
                RemoveListener(listener);
            }
        }

        public void Clear()
        {
            _gameListeners.Clear();
            _gameUpdateListeners.Clear();
            _gameFixedUpdateListeners.Clear();
            _gameLateUpdateListeners.Clear();
        }

        public void StartGame()
        {
            State = GameState.Playing;
            foreach (var stateListener in _gameListeners)
                if (stateListener is IGameStartListener onGameStarted)
                    onGameStarted.OnGameStart();
        }

        public void PauseGame()
        {
            State = GameState.Paused;
            foreach (var stateListener in _gameListeners)
                if (stateListener is IGamePauseListener onGameStarted)
                    onGameStarted.OnGamePause();
        }

        public void ResumeGame()
        {
            State = GameState.Playing;
            foreach (var stateListener in _gameListeners)
                if (stateListener is IGameResumeListener onGameStarted)
                    onGameStarted.OnGameResume();
        }

        public void FinishGame()
        {
            State = GameState.Finished;
            foreach (var stateListener in _gameListeners)
                if (stateListener is IGameFinishListener onGameStarted)
                    onGameStarted.OnGameFinish();
        }

        private void Update()
        {
            if (State != GameState.Playing)
                return;
            
            var deltaTime = Time.deltaTime;
            foreach (var gameUpdateListener in _gameUpdateListeners)
            {
                gameUpdateListener.OnGameUpdate(deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            if (State != GameState.Playing)
                return;
            
            var deltaTime = Time.deltaTime;
            foreach (var gameUpdateListener in _gameFixedUpdateListeners)
            {
                gameUpdateListener.OnGameFixedUpdate(deltaTime);
            }
        }
        
        private void LateUpdate()
        {
            if (State != GameState.Playing)
                return;
            
            var deltaTime = Time.deltaTime;
            foreach (var gameUpdateListener in _gameLateUpdateListeners)
            {
                gameUpdateListener.OnGameLateUpdate(deltaTime);
            }
        }
    }
}