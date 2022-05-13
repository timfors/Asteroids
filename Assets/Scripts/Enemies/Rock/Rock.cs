using UnityEngine;

public class Rock : MonoBehaviour, IPositionAdapter, IEulerAnglesAdapter, IEnemy
{
    [SerializeField] private RockData data;

    private RockLogic logic;

    public Vector3 Position { get => transform.position; set => transform.position = value; }
    public Vector3 EulerAngles { get => transform.eulerAngles; set => transform.eulerAngles = value; }

    private void Awake()
    {
        logic = new RockLogic(this, data);

        logic.OnDie += () => Die();
    }

    public void Die()
    {
        var sessionManger = SessionManager.instance;
        var enemiesHandler = sessionManger.SessionData.Enemies;

        sessionManger.AddScore(data.Points);
        enemiesHandler.Remove(this);

        if (data.SmallerRock)
            for (int i = 0; i < data.RocksCount; i++)
            {
                var newRock = Instantiate<Rock>(data.SmallerRock, Position, transform.rotation);
                enemiesHandler.Add(newRock);
            }

        Destroy(gameObject);
    }

    private void Update()
    {
        logic.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.Hit(collision);
    }
}