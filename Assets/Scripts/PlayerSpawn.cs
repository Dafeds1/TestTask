using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    public void Spawn()
    {
        GameObject player = Instantiate(_player, Vector3.up, Quaternion.identity);
        player.transform.SetParent(transform);
    }
}
