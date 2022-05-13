using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShipData", menuName = "Enemies/Ship", order = 51)]
public class EnemyShipData : EnemyData
{

    [HideInInspector] public PhysicsMovementData MovementData;
}