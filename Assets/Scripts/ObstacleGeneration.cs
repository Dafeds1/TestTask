using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle;

    void Start()
    {
        GameObject obstacle = Instantiate(_obstacle, new Vector3(transform.position.x,Random.Range(2, 6),transform.position.z), Quaternion.identity);
        obstacle.transform.SetParent(transform);
    }

}
