using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    private const string NUMBER_ATTEMPT = "Number";
    private float _durationLastGame;
    private int _numberAttempt
    {
        get => PlayerPrefs.GetInt(NUMBER_ATTEMPT);
        set => PlayerPrefs.SetInt(NUMBER_ATTEMPT, _numberAttempt);
    }

    // Update is called once per frame
    void Update()
    {
        _durationLastGame += Time.time;        
    }
    public void AddNumberAttempt()
    {
        _numberAttempt++;
    }
}
