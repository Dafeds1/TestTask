using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
    private int _idButton;
    [SerializeField]
    private SelectDifficulty _selectedDifficulty;

    public void SendId()
    {
        _selectedDifficulty.SelectedDifficulty(_idButton);
    }
    
}
