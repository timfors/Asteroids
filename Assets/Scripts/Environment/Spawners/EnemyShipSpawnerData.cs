using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShipSpawnerData", menuName = "EnemySpawner/Enemy Ship", order = 51)]
public class EnemyShipSpawnerData : EnemySpawnerData
{
    [SerializeField] private int maxShips;
    [SerializeField] private EnemyShip[] shipInstances;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    public int MaxShips { get => maxShips; }
    public EnemyShip[] ShipInstances { get => shipInstances; }
    public float MinDelay { get => minDelay; }
    public float MaxDelay { get => maxDelay; }

    public override EnemySpawner CreateSpawner(SessionData sessionData)
    {
        return new EnemyShipSpawner(sessionData, this);
    }
}