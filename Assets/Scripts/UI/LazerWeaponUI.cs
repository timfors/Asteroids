using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerWeaponUI : WeaponUI
{
    [Header("Bullet Instance")]
    [SerializeField] private BulletUI bulletInstance;
    [Header("Settings")]
    [SerializeField]private WeaponReloadTimer timer;

    private int lastAmmo = 0;
    private List<BulletUI> ammo = new List<BulletUI>();
    private ReloadingWeapon weapon;

    public override void Init(IWeapon weapon)
    {
        this.weapon = (ReloadingWeapon)weapon;
        lastAmmo = this.weapon.CurrentAmmo;
        timer.Init(this.weapon);
        CreateAmmo();
        UpdateAmmo();
    }

    private void CreateAmmo()
    {
        ammo.Add(bulletInstance);
        for (int i = 1; i < weapon.MaxAmmo; i++)
        {
            var bullet = Instantiate<BulletUI>(bulletInstance, transform);
            ammo.Add(bullet);
        }
        ammo.Reverse();
    }

    private void UpdateAmmo()
    {
        for (int i = 0; i < weapon.MaxAmmo; i++)
            ammo[i].SetState(i < weapon.CurrentAmmo);
    }
    // Update is called once per frame
    void Update()
    {
        if (lastAmmo != weapon.CurrentAmmo)
        {
            UpdateAmmo();
            lastAmmo = weapon.CurrentAmmo;
        }
    }
}
