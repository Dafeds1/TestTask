using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static event Action<float> OnRoadSpeed;
    public static event Action<bool> OnRunningGame;
    public static event Action<bool> OnGameOver;

    private bool _isRunning;
    public bool IsRunning => _isRunning;

    public void SetRoadSpeed(float speed)
    {
        OnRoadSpeed?.Invoke(speed);
    }

    public void SetGameState()
    {
        _isRunning = true;
        OnRunningGame?.Invoke(_isRunning);
    }

    public void GameOver()
    {
        _isRunning = false;
        OnGameOver?.Invoke(_isRunning);
    }
}
