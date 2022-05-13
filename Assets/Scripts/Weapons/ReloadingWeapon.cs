using UnityEngine;

public class ReloadingWeapon : IWeapon
{
    private Transform parentTransform;
    private ReloadingWeaponData weaponData;

    private int currentAmmo;
    private bool isShooting = false;
    private float lastShootTime;
    private float lastReloadTime;

    public ReloadingWeapon(ReloadingWeaponData data, Transform parent)
    {
        parentTransform = parent;
        weaponData = data;
        currentAmmo = weaponData.StartAmmo;
    }

    public bool IsShooting { get => isShooting; }
    public bool IsReloading { get => currentAmmo != weaponData.MaxAmmo; }
    public int MaxAmmo { get => weaponData.MaxAmmo; }
    public int CurrentAmmo { get => currentAmmo; }
    public float ReloadLeft { get => weaponData.ReloadTime - (Time.time - lastReloadTime); }
    public float ReloadProgress { get => (Time.time - lastReloadTime) / weaponData.ReloadTime; }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Update()
    {
        CheckReload();
        if (isShooting)
            TryShoot();
    }

    private void TryShoot()
    {
        if (Time.time - lastShootTime > weaponData.ShootDelay && currentAmmo != 0)
        {
            GameObject.Instantiate<WeaponProjectile>(weaponData.Projectile, parentTransform);

            currentAmmo--;
            lastShootTime = Time.time;
        }
    }

    private void CheckReload()
    {
        if (!IsReloading)
        {
            lastReloadTime = Time.time;
            return;
        }
        if (Time.time - lastReloadTime >= weaponData.ReloadTime)
        {
            currentAmmo++;
            lastReloadTime = Time.time;
        }
    }

    public WeaponUI CreateUI()
    {
        if (!weaponData.WeaponUI)
            return null;
        var ui = GameObject.Instantiate<WeaponUI>(weaponData.WeaponUI);
        ui.Init(this);
        return ui;
    }
}