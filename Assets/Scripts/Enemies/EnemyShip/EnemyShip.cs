using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, ILocalPositionAdatper, IPositionAdapter, IEulerAnglesAdapter, IEnemy
{
    [SerializeField] private EnemyShipData data;

    private EnemyShipLogic enemyLogic;

    public Vector3 EulerAngles
    {
        get => transform.eulerAngles;
        set => transform.eulerAngles = value;
    }

    public Vector3 LocalPosition
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
    
    public void Awake()
    {
        var sessionManager = SessionManager.instance;
        enemyLogic = new EnemyShipLogic(this, sessionManager.SessionData.PlayerShip, data);

        enemyLogic.OnDie += () => Die();
    }

    public void Die()
    {
        var sessionManager = SessionManager.instance;

        sessionManager.AddScore(data.Points);
        sessionManager.SessionData.Enemies.Remove(this);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        enemyLogic.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyLogic.Hit(collision);
    }
}
