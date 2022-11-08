using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _startMenu;
    [SerializeField]
    private GameObject _uiObject;
    [SerializeField]
    private GameObject _gameArea;
    [SerializeField]
    private GameObject _gameOverMenu;

    private EventBus _eventBus;
    [SerializeField]
    private RoadGeneration _roadGeneration;
    [SerializeField]
    private DataGame _dataGame;
    [SerializeField]
    private PlayerSpawn _palyerSpawn;
    private void Awake()
    {
        _eventBus = FindObjectOfType<EventBus>();
        EventBus.OnRoadSpeed += SendDataSpeed;
        EventBus.OnGameOver += ShowGameOverWindow;
    }
    private void OnDestroy()
    {
        EventBus.OnRoadSpeed -= SendDataSpeed;
        EventBus.OnGameOver -= ShowGameOverWindow;
    }

    public void StartGame()
    {
        _gameArea.SetActive(true);
        _startMenu.SetActive(false);
        _uiObject.SetActive(false);
        _roadGeneration.ResetLevelItem();
        _palyerSpawn.Spawn();
        _dataGame.AddNumberAttempt();
        _eventBus.SetGameState();
    }
    public void ShowGameOverWindow(bool value)
    {
        _gameArea.SetActive(value);
        _uiObject.SetActive(!value);
        _gameOverMenu.SetActive(!value);

    }

    public void RetryGame()
    {
        _gameArea.SetActive(true);
        _gameOverMenu.SetActive(false);
        _uiObject.SetActive(false);
        _roadGeneration.ResetLevelItem();
        _palyerSpawn.Spawn();
        _dataGame.AddNumberAttempt();
        _eventBus.SetGameState();
    }

    public void ChooseDifficulty()
    {
        _gameOverMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    private void SendDataSpeed(float speed)
    {
        _roadGeneration.SettingsSave(speed);    
    }

}
