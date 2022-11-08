using UnityEngine;

public class SelectDifficulty : MonoBehaviour
{
    [SerializeField]
    private DifficultyLevel[] _difficultyLevel;
    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = FindObjectOfType<EventBus>();
    }

    public void SelectedDifficulty(int id)
    {
        _eventBus.SetRoadSpeed(_difficultyLevel[id].Speed);                 
    } 
}
