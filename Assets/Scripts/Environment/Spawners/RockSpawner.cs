using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : EnemySpawner
{
    private RockSpawnerData data;

    public RockSpawner (SessionData sessionData, RockSpawnerData data)
    {
        this.container = sessionData.Enemies;
        this.data = data;
    }

    public bool CheckSpawnConditions()
    {
        return container.Get<Rock>().Count < data.MaxRocks;
    }

    private Rock GetInstance()
    {
        return data.RockInstances[Random.Range(0, data.RockInstances.Length)];
    }

    public override bool TrySpawn(Vector3 position)
    {
        if (!CheckSpawnConditions())
            return false;

        var instance = GetInstance();

        Spawn<Rock>(instance, position);

        return true;
    }
}
