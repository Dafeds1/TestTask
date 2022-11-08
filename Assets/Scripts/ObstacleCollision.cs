using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private EventBus _eventBus;
    private void Awake()
    {
        _eventBus = FindObjectOfType<EventBus>();    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _eventBus.GameOver();
            Destroy(collision.gameObject);
        }
    }
}
