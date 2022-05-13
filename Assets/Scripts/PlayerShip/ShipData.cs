using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShipData", menuName = "Ship Data/Ship", order = 51)]
public class ShipData : ScriptableObject
{
    [Header("Object Instance")]
    [SerializeField] private Ship ship;
    [Header("Armory Settings")]
    [SerializeField] private WeaponData mainWeapon;
    [SerializeField] private WeaponData secondWeapon;

    [Header("Movement Settings")]
    [HideInInspector][SerializeField] public PhysicsMovementData MovementData;

    public Ship Ship { get => ship; }
    public WeaponData MainWeapon { get => mainWeapon; }
    public WeaponData SecondWeapon { get => secondWeapon; }
}