using UnityEngine;

[CreateAssetMenu(fileName = "ReloadingWeaponData", menuName = "Weapons/Reloading Weapon", order = 51)]
public class ReloadingWeaponData : WeaponData
{
    [SerializeField] private int startAmmo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float reloadTime;

    public int StartAmmo { get => startAmmo; }
    public int MaxAmmo { get => maxAmmo; }
    public float ReloadTime { get => reloadTime; }
}