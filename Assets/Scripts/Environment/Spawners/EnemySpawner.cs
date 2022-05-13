using UnityEngine;

public abstract class EnemySpawner
{
    protected EnemyContainer container;

    public virtual void Spawn<T>(T enemy, Vector3 position) where T : MonoBehaviour, IEnemy
    {
        var newEnemy = GameObject.Instantiate<T>(enemy);
        newEnemy.transform.position = position;

        container.Add(newEnemy);
    }

    public virtual bool TrySpawn(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}
