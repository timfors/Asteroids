using UnityEngine;

public class PhysicsMovementSimulation
{
    private Vector2 moveVelocityScale;
    private float rotationVelocityScale;

    private Vector2 moveVelocity;
    private float rotationVelocity;

    private PhysicsMovementData data;

    public PhysicsMovementSimulation(PhysicsMovementData movementData)
    {
        data = movementData;
        moveVelocityScale = movementData.moveVelocityScale;
        rotationVelocityScale = movementData.rotationVelocityScale;
    }

    public Vector2 MoveVelocity
    {
        get => moveVelocity;
        set => moveVelocity = value;
    }

    public float RotationVelocity
    {
        get => rotationVelocity;
        set => rotationVelocity = value;
    }
    public float RotationVelocityScale { get => rotationVelocityScale; }
    public Vector2 MovementVelocityScale { get => moveVelocityScale; }

    public PhysicsMovementData Data { get => data; }

    public static Vector2 GetUpDirection(float angles)
    {
        float r = -angles * Mathf.Deg2Rad;
        return new Vector2(Mathf.Sin(r), Mathf.Cos(r));
    }
    private float UpdateVelocity(float currentVelocity, float targetVelocity, float maxDelta)
    {
        if (currentVelocity == targetVelocity)
            return currentVelocity;

        int direction = currentVelocity > targetVelocity ? -1 : 1;
        float delta = Mathf.Abs(targetVelocity - currentVelocity);

        delta = delta > maxDelta ? maxDelta : delta;
        return currentVelocity + delta * direction;
    }

    public float LookAt(float rotation, Vector3 position, Vector3 targetPos, float maxDelta)
    {
        Vector3 diff = targetPos - position;
        diff.Normalize();

        Vector3 up = GetUpDirection(rotation);

        float delta = Vector2.SignedAngle(diff, up);
        if (Mathf.Abs(delta) < maxDelta)
            return rotation - delta;
        return rotation - maxDelta * (delta > 0 ? 1 : -1);
    }

    public Vector2 UpdateMovementVelocity(Vector2 currentVelocity, Vector2 targetVelocity, float multiplier)
    {
        Vector2 newVelocity;
        newVelocity.x = UpdateVelocity(moveVelocity.x, targetVelocity.x, moveVelocityScale.x * multiplier);
        newVelocity.y = UpdateVelocity(moveVelocity.y, targetVelocity.y, moveVelocityScale.y * multiplier);

        return newVelocity;
    }

    public Vector2 UpdateMovementVelocity(Vector2 currentVelocity, Vector2 targetVelocity, Vector2 multiplier)
    {
        Vector2 newVelocity;
        newVelocity.x = UpdateVelocity(moveVelocity.x, targetVelocity.x, moveVelocityScale.x * multiplier.x);
        newVelocity.y = UpdateVelocity(moveVelocity.y, targetVelocity.y, moveVelocityScale.y * multiplier.y);

        return newVelocity;
    }

    public float UpdateRotationScale(float currentVelocity, float targetVelocity, float multiplier)
    {
        return UpdateVelocity(currentVelocity, targetVelocity, rotationVelocityScale * multiplier);
    }

    public Vector2 UpdatePos(Vector2 position, Vector2 direction, float multiplier)
    {
        return position + direction * multiplier;
    }

    public float UpdateRotation(float rotation, float direction, float multiplier)
    {
        return rotation + direction * multiplier;
    }
}