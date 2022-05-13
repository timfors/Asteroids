using UnityEngine;

[CreateAssetMenu(fileName = "RockSpawnerData", menuName = "EnemySpawner/Rock", order = 51)]
public class RockSpawnerData : EnemySpawnerData
{
    [SerializeField] private int maxRocks;
    [SerializeField] private Rock[] rockInstances;

    public int MaxRocks { get => maxRocks; }
    public Rock[] RockInstances { get => rockInstances; }

    public override EnemySpawner CreateSpawner(SessionData sessionData)
    {
        return new RockSpawner(sessionData, this);
    }
}
