using System;
using System.Collections;
using UnityEngine;

namespace Level
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private int delay;
        [SerializeField] private GameManager.GameManager gameManager;

        public void StartGame()
        {
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            while (delay>0)
            {
                print(delay);
                yield return new WaitForSeconds(1);
                delay--;
            }

            print("Start");
            gameManager.StartGame();
        }
    }
}