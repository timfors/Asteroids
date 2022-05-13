using System.Collections.Generic;

public class EnemyContainer
{
    private List<IEnemy> enemies = new List<IEnemy>();

    public void Add(IEnemy newEnemy)
    {
        if (newEnemy != null)
            enemies.Add(newEnemy);
    }

    public bool Remove(IEnemy enemy)
    {
        return enemies.Remove(enemy);
    }

    public List<T> Get<T>() where T : IEnemy
    {
        List<T> list = new List<T>();

        foreach (var enemy in enemies)
            if (enemy.GetType() == typeof(T))
                list.Add((T)enemy);

        return list;
    }
}
