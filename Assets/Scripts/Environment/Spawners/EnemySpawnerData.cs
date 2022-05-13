using UnityEngine;

public abstract class EnemySpawnerData : ScriptableObject
{
    public virtual EnemySpawner CreateSpawner(SessionData sessionData) { throw new System.NotImplementedException(); }
}