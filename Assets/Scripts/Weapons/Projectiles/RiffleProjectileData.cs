using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RiffleWeaponData", menuName = "Weapons/Projectile/Riffle", order = 51)]
public class RiffleProjectileData : WeaponProjectileData
{   
    [Header("Movement Data")]
    [HideInInspector][SerializeField] public MovementData MovementData;
}
