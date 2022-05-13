using UnityEngine;

[System.Serializable]
public struct PhysicsMovementData
{
    public Vector2 moveVelocityScale;
    public Vector2 maxMoveSpeed;

    public float rotationVelocityScale;
    public float maxRotationSpeed;
}