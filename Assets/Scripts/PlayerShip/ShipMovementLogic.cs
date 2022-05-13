using UnityEngine;
using System;

public class ShipMovementLogic : ITeleportable
{
    private Ship ship;
    private PhysicsMovementSimulation movement;
    private ShipInput input;
    private Vector2 moveDirection;

    public event Action OnDie;

    public ShipMovementLogic(Ship ship, PhysicsMovementSimulation movement, ShipInput input)
    {
        this.ship = ship;
        this.movement = movement;
        this.input = input;
    }

    public Vector2 MovenentVelocity
    {
        get => movement.MoveVelocity;
    }

    public void UpdatePosition()
    {
        if (input.MoveDirection != 0)
            moveDirection = PhysicsMovementSimulation.GetUpDirection(ship.EulerAngles.z);

        Vector2 targetMoveVelocity = input.MoveDirection * Vector2.Scale(movement.Data.maxMoveSpeed, moveDirection);
        Vector2 maxDeltaVelocity = new Vector2(Mathf.Abs(moveDirection.x), Mathf.Abs(moveDirection.y));

        movement.MoveVelocity = movement.UpdateMovementVelocity(movement.MoveVelocity, targetMoveVelocity, maxDeltaVelocity * Time.fixedDeltaTime);
        ship.LocalPosition = movement.UpdatePos(ship.LocalPosition, movement.MoveVelocity, Time.fixedDeltaTime);
    }

    public void UpdateRotation()
    {
        float targetVelocity = movement.Data.maxRotationSpeed * input.RotationDirection;

        movement.RotationVelocity = movement.UpdateRotationScale(movement.RotationVelocity, targetVelocity, 1);
        float newRotation = movement.UpdateRotation(ship.EulerAngles.z, movement.RotationVelocity, Time.fixedDeltaTime);

        ship.EulerAngles = Vector3.forward * newRotation;
    }

    public void FixedUpdate()
    {
        UpdateRotation();
        UpdatePosition();
    }

    public void Update()
    {
        input.Update();
    }

    public void Teleport(IPortal portal)
    {
        ship.Position = portal.GetPos(ship.Position);
    }

    public void Hit(Collider2D collision)
    {
        if (collision.TryGetComponent<IPortal>(out var portal))
            Teleport(portal);
        if (collision.TryGetComponent<IEnemy>(out var enemy))
            OnDie();
    }
}