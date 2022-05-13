public class SessionData
{
    private Ship playerShip;
    private int score;
    private EnemyContainer enemiesHandler;

    public SessionData(Ship playerShip)
    {
        this.playerShip = playerShip;
        this.score = 0;
        this.enemiesHandler = new EnemyContainer();
    }

    public SessionData() : this(null) {}

    public Ship PlayerShip { get => playerShip; set => playerShip = value; }
    public int Score { get => score; set => score = value; }
    public EnemyContainer Enemies { get => enemiesHandler; }
}