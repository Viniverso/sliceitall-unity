using Internal.Singleton;
using entities.brick.controller;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int brickPontuation = 10;

    private int currentPlayerScore;

    // Start is called before the first frame update
    void Start()
    {
        BrickController.OnNotifyDestruct += OnNotifyDestruct;
        currentPlayerScore = 0;
    }

    public void OnNotifyDestruct()
    {
        SetPlayerScore();
    }

    private void SetPlayerScore()
    {
        currentPlayerScore += brickPontuation;
    }

    private void OnDestroy()
    {
        BrickController.OnNotifyDestruct -= OnNotifyDestruct;
    }
}