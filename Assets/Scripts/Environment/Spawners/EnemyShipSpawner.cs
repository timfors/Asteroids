using UnityEngine;

internal class EnemyShipSpawner : EnemySpawner
{
    private EnemyShipSpawnerData data;
    private float lastSpawn;
    private float currentDelay;

    public EnemyShipSpawner(SessionData sessionData, EnemyShipSpawnerData enemyShipSpawnerData)
    {
        this.container = sessionData.Enemies;
        this.data = enemyShipSpawnerData;
        this.lastSpawn = Time.time;
        this.currentDelay = GenerateDelay();
    }

    private float GenerateDelay()
    {
        return Random.Range(data.MinDelay, data.MaxDelay);
    }

    public bool CheckSpawnConditions()
    {
        return container.Get<EnemyShip>().Count < data.MaxShips && Time.time - lastSpawn > currentDelay;
    }

    private EnemyShip GetInstance()
    {
        return data.ShipInstances[Random.Range(0, data.ShipInstances.Length)];
    }

    public override bool TrySpawn(Vector3 position)
    {
        if (!CheckSpawnConditions())
            return false;

        var instance = GetInstance();

        Spawn<EnemyShip>(instance, position);

        currentDelay = GenerateDelay();
        lastSpawn = Time.time;

        return true;
    }

}