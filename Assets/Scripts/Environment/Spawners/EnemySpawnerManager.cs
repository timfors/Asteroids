using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawnerData[] spawnerDatas;
    [SerializeField] private SpawnZone[] spawnZones;

    private EnemySpawnerManagerLogic logic;
    private SessionData sessionData;
    private Dictionary<EnemySpawnerData, EnemySpawner> spawners = new Dictionary<EnemySpawnerData, EnemySpawner>();

    public void Init(SessionData sessionData)
    {
        this.sessionData = sessionData;

        foreach (var spawnerData in spawnerDatas)
            AddSpawner(spawnerData);

        this.logic = new EnemySpawnerManagerLogic(spawners, spawnZones);
    }

    public void AddSpawner(EnemySpawnerData spawnerData)
    {
        if (spawners.ContainsKey(spawnerData))
            throw new Exception("Key already exists");

        spawners[spawnerData] = spawnerData.CreateSpawner(sessionData);
    }

    public void RemoveSpawner(EnemySpawnerData spawnerData)
    {
        spawners.Remove(spawnerData);
    }

    // Update is called once per frame
    void Update()
    {
        logic.Update();
    }
}
