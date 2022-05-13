using UnityEngine;

public class SingleShootWeapon : IWeapon
{
    private Transform parentTransform;

    private  WeaponData weaponData;
    private bool isShooting = false;
    private float lastShootTime;

    public bool IsShooting { get => isShooting; }

    public SingleShootWeapon(WeaponData weaponData, Transform ownerTransform)
    {
        this.weaponData = weaponData;
        this.parentTransform = ownerTransform;
    }

    public virtual void StartShooting()
    {
        isShooting = true;
    }

    protected virtual void TryShoot()
    {   
        if (Time.time - lastShootTime > weaponData.ShootDelay)
        {
            var projectile = GameObject.Instantiate<WeaponProjectile>(weaponData.Projectile, parentTransform);
            
            lastShootTime = Time.time;
        }
    }

    public virtual void Update()
    {
        if (isShooting)
            TryShoot();

    }

    public virtual void StopShooting()
    {
        isShooting = false;
    }

    public virtual WeaponUI CreateUI()
    {
        if (!weaponData.WeaponUI)
            return null;
        var ui = GameObject.Instantiate<WeaponUI>(weaponData.WeaponUI);
        ui.Init(this);
        return ui;
    }
}