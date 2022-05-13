using UnityEngine;

[CreateAssetMenu(fileName = "Infinity Weapon Data", menuName = "Weapons/Infinity Weapon", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private WeaponProjectile projectile;
    [SerializeField] private WeaponUI weaponUI;
    [SerializeField] private float shootDelay;

    public WeaponProjectile Projectile { get { return projectile; } }
    public WeaponUI WeaponUI { get { return weaponUI; } }
    public float ShootDelay { get { return shootDelay; } }
}
