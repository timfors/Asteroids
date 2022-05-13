using UnityEngine;
using System;

public class EnemyShipLogic
{
    private Ship target;
    private EnemyShipData data;
    private EnemyShip ship;
    private PhysicsMovementSimulation movement;

    public event Action OnDie;

    public EnemyShipLogic(EnemyShip ship, Ship target, EnemyShipData data)
    {
        this.ship = ship;
        this.target = target;
        this.data = data;
        this.movement = new PhysicsMovementSimulation(data.MovementData);

        movement.RotationVelocity = data.MovementData.maxRotationSpeed;
    }

    public Vector2 MovenentVelocity
    {
        get => movement.MoveVelocity;
    }

    public void UpdatePosition()
    {
        Vector2 moveDirection = PhysicsMovementSimulation.GetUpDirection(ship.EulerAngles.z);
        moveDirection.Normalize();

        Vector2 targetMoveVelocity = Vector2.Scale(movement.Data.maxMoveSpeed, moveDirection);
        Vector2 maxDeltaVelocity = new Vector2(Mathf.Abs(moveDirection.x), Mathf.Abs(moveDirection.y));

        movement.MoveVelocity = movement.UpdateMovementVelocity(movement.MoveVelocity,
            targetMoveVelocity, maxDeltaVelocity * Time.fixedDeltaTime);
        ship.LocalPosition = movement.UpdatePos(ship.LocalPosition, movement.MoveVelocity, Time.fixedDeltaTime);
    }

    public void UpdateRotation()
    {
        ship.EulerAngles = Vector3.forward * movement.LookAt(ship.EulerAngles.z, ship.Position,
            target.Position, data.MovementData.rotationVelocityScale * Time.fixedDeltaTime);
    }

    public void FixedUpdate()
    {
        UpdateRotation();
        UpdatePosition();
    }

    public void Hit(Collider2D collision)
    {
        if (collision.TryGetComponent<WeaponProjectile>(out var projectile))
            OnDie();
    }
}