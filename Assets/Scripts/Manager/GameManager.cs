using System.Collections.Generic;
using Internal.Singleton;

using entities.impl;
using entities.brick.controller;
using Manager.model;

using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int brickPontuation = 10;

        private int currentPlayerScore;

        private GameState currentGameState;

        private List<DestructibleObject> availableBrickControllers;


        public GameState CurrentGameState
        {
            get { return currentGameState; }
            set
            {
                if (currentGameState != value)
                    currentGameState = value;
            }
        }

        private void Awake()
        {
            GameStart();
        }


        private void GameStart()
        {
            CurrentGameState = GameState.START;

            BrickController.OnNotifyDestruct += OnNotifyDestruct;

            availableBrickControllers = new List<DestructibleObject>();
            BrickController[] _bricksOnScene = FindObjectsOfType<BrickController>();

            availableBrickControllers.AddRange(_bricksOnScene);
        }

        // Start is called before the first frame update
        void Start()
        {
            CurrentGameState = GameState.INGAME;

            currentPlayerScore = 0;
        }

        public void OnNotifyDestruct(DestructibleObject brickController)
        {
            SetPlayerScore();

            RemoveBrick((BrickController)brickController);
        }

        private void SetPlayerScore()
        {
            currentPlayerScore += brickPontuation;

            UIManager.Instance.SetPlayerScore(currentPlayerScore);
        }

        private void RemoveBrick(BrickController _brick)
        {
            if (availableBrickControllers.Contains(_brick))
            {
                availableBrickControllers.Remove(_brick);
            }

            if (availableBrickControllers.Count == 0)
            {
                CurrentGameState = GameState.END;
            }
        }

        private void OnDestroy()
        {
            BrickController.OnNotifyDestruct -= OnNotifyDestruct;
        }
    }
}