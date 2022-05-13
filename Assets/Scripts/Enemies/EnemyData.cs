using UnityEngine;

public class EnemyData : ScriptableObject
{
    [SerializeField] private int points;

    public int Points { get => points; }
}
