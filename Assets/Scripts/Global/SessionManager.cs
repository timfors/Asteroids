using UnityEngine;

public class SessionManager : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] private GameSettings gameSettings;
    [Header("Level")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private EnemySpawnerManager enemySpawnerManager;
    [Header("UI")]
    [SerializeField] private SessionUIManager UIManager;
    [SerializeField] private LooseWindow looseWindow;

    private SessionData sessionData;

    public static SessionManager instance;

    public SessionManager()
    {
        instance = this;
    }

    public SessionData SessionData { get => sessionData; }

    public void Init(GameSettings settings)
    {
        var player = Instantiate<Ship>(settings.PlayerShip, playerSpawnPoint.position, playerSpawnPoint.rotation);

        sessionData = new SessionData(player);
        player.Logic.OnDie += () => UIManager.CreateInterface(looseWindow, SessionData);
        enemySpawnerManager.Init(sessionData);

        UIManager.Init(sessionData);
    }

    private void Start()
    {
        Init(gameSettings);
    }

    public void AddScore(int points)
    {
        sessionData.Score += points;
    }
}
