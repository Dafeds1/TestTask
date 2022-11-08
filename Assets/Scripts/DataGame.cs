using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame : MonoBehaviour
{
    private const string NUMBER_ATTEMPT = "Number";
    private float _durationLastGame;
    public float DurationLastGame => _durationLastGame;
    private float _savedSpeed;
    private int _numberAttempt
    {
        get => PlayerPrefs.GetInt(NUMBER_ATTEMPT);
        set => PlayerPrefs.SetInt(NUMBER_ATTEMPT, value);
    }
    [SerializeField]
    private GameOverMenu _gameOverMenu;
    private void Awake()
    {
        EventBus.OnRoadSpeed += SaveSpeed;
        EventBus.OnRunningGame += StartDuration;
        EventBus.OnGameOver += StopDuration;
    }
    private void OnDestroy()
    {
        EventBus.OnRoadSpeed -= SaveSpeed;
        EventBus.OnRunningGame -= StartDuration;
        EventBus.OnGameOver -= StopDuration;
    }

    public void AddNumberAttempt()
    {
        _numberAttempt = _numberAttempt + 1;
    }
    private void SaveSpeed(float speed)
    {
        _savedSpeed = speed;
    }
    private void StartDuration(bool value)
    {
        _durationLastGame = 0;
        StartCoroutine(Duration(value));
    }
    private IEnumerator Duration(bool isRunning)
    {
        while (isRunning == true)
        {
            _durationLastGame++;
            yield return new WaitForSeconds(1);
        }
    }

    private void StopDuration(bool value) 
    {
        StopCoroutine(Duration(value));
        _gameOverMenu.DispayingDataGame(_durationLastGame, _numberAttempt);
    }
}
