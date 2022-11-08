using UnityEngine;

[CreateAssetMenu(order = 51, fileName = "New difficulty", menuName = "Difficulty/ Create new Difficulty")]
public class DifficultyLevel : ScriptableObject
{
    [SerializeField]
    private int _id;
    public int Id => _id;
    [SerializeField]
    private float _speed;
    public float Speed => _speed;

}
