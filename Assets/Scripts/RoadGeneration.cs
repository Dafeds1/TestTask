using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject _road;
    [SerializeField]
    private GameObject _roadWithObstacle;
    private List<GameObject> _roads = new List<GameObject>();
    private int _obstacleInterval = 2;
    private float _horizontalSpeed;
    private int _maxRoadCount = 6;


    // Update is called once per frame
    void Update()
    {
        MovementRoads();       
    }

    private void MovementRoads()
    {
            foreach (GameObject road in _roads)
            {
                road.transform.position -= new Vector3(0,0, _horizontalSpeed * Time.deltaTime);
            }
            if (_roads[0].transform.position.z < -10)
            {
                Destroy(_roads[0]);
                _roads.RemoveAt(0);
                CreateNextRoad();
            }  
    }
    public void SettingsSave(float speed)
    {
        _horizontalSpeed = speed;
        
    }
    
    public void ResetLevelItem()
    {
        while(_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
        for (int i = 0; i < _maxRoadCount; i++)
        {

            CreateNextRoad();
            
        }

    }
    private void CreateNextRoad()
    {
        Vector3 position;
        if (_roads.Count > 0)
        {
            position = _roads[_roads.Count - 1].transform.position + new Vector3(0,0,10);
        }
        else position = Vector3.zero;
        if (_obstacleInterval == 0)
        {
            GameObject roadWithObstacle = Instantiate(_roadWithObstacle, position, Quaternion.identity);
            roadWithObstacle.transform.SetParent(transform);
            _roads.Add(roadWithObstacle);
            _obstacleInterval = 2;
        }
        else
        {
            GameObject road = Instantiate(_road, position, Quaternion.identity);
            road.transform.SetParent(transform);
            _roads.Add(road);
            _obstacleInterval--;
        }
        
    }
}
                               