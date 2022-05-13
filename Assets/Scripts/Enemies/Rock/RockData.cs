using UnityEngine;

[CreateAssetMenu(fileName = "RockData", menuName = "Enemies/Rock", order = 51)]
public class RockData : EnemyData
{
    [Header("After Destroy")]
    [SerializeField] private Rock smallerRock;
    [SerializeField] private int rocksCount;

    [HideInInspector] public MovementData MovementData;

    public Rock SmallerRock { get => smallerRock; }
    public int RocksCount { get => rocksCount; }
}
