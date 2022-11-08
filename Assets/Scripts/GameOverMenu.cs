using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _durationLastGameTxt;
    [SerializeField]
    private TextMeshProUGUI _numberAttemptTxt;
    
    public void DispayingDataGame(float duration, int number)
    {
        _durationLastGameTxt.text = "�����������������: " + duration.ToString();
        _numberAttemptTxt.text = "���������� �������: " + number.ToString();
    }
}
