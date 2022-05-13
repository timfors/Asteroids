using System;
using UnityEngine;

public class RiffleProjectileLogic : ITeleportable
{
    private Vector3 moveDirection;
    private MovementData movementData;
    private float bornTime;

    protected RiffleProjectile projectile;
    protected RiffleProjectileData projectileData;

    public event Action OnDestroy;

    public RiffleProjectileLogic(RiffleProjectile projectile, RiffleProjectileData projectileData, Vector2 direction)
    {
        this.projectile = projectile;
        this.projectileData = projectileData;
        this.movementData = projectileData.MovementData; 
        this.moveDirection = direction;

        bornTime = Time.time;
    }

    public bool CheckLifeTime()
    {
        return Time.time - bornTime < projectileData.LifeTime;
    }

    public void Update()
    {
        if (!CheckLifeTime())
            OnDestroy();
    }

    public void FixedUpdate()
    {
        projectile.Position = Vector3.MoveTowards(projectile.Position, projectile.Position + moveDirection,
            movementData.movementSpeed * Time.fixedDeltaTime);
    }

    public void Hit(Collider2D collision)
    {
        if (collision.TryGetComponent<IPortal>(out var portal))
            Teleport(portal);
        if (collision.TryGetComponent<IEnemy>(out var enemy))
            OnDestroy();
    }

    public void Teleport(IPortal portal)
    {
        projectile.Position = portal.GetPos(projectile.Position); ;
    }
}