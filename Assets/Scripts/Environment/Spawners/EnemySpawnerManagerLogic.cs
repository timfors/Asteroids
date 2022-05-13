using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManagerLogic
{
    private Dictionary<EnemySpawnerData, EnemySpawner> spawners;
    private SpawnZone[] spawnZones;
    private int currentZone;
    private Vector2 currentSpawnPoint;

    public EnemySpawnerManagerLogic(Dictionary<EnemySpawnerData, EnemySpawner> spawners, SpawnZone[] spawnZones)
    {
        this.spawners = spawners;
        this.spawnZones = spawnZones;
        CurrentZone = 0;
        currentSpawnPoint = spawnZones[CurrentZone].GetRandomPos();
    }

    private int CurrentZone
    {
        get => currentZone;
        set
        {
            if (value < 0)
                currentZone = spawnZones.Length - 1;
            else if (value >= spawnZones.Length)
                currentZone = 0;
            else
                currentZone = value;
        }
    }

    private void UpdateSpawnPoint()
    {
        CurrentZone++;
        currentSpawnPoint = spawnZones[CurrentZone].GetRandomPos();
    }

    public void Update()
    {
        foreach (var spawner in spawners.Values)
            if (spawner.TrySpawn(currentSpawnPoint))
                UpdateSpawnPoint();
    }

}