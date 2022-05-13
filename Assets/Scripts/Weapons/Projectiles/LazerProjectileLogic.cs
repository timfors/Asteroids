using System;
using UnityEngine;

public class LazerProjectileLogic
{
    private LazerProjectile projectile;
    private LazerProjectileData projectileData;
    private Vector3 startScale;
    private float bornTime;

    public event Action OnDestroy;
    public LazerProjectileLogic(LazerProjectile projectile, LazerProjectileData projectileData)
    {
        this.projectileData = projectileData;
        this.projectile = projectile;
        this.startScale = projectile.Scale;
        this.bornTime = Time.time;

        UpdateScale();
    }

    public void Update()
    {
        UpdateScale();
        if (Time.time - bornTime > projectileData.LifeTime)
            OnDestroy();
    }

    public void UpdateScale()
    {
        float progress = (Time.time - bornTime) / projectileData.LifeTime;
        Vector3 newScale = startScale;

        newScale.x *= projectileData.ScaleCurve.Evaluate(progress);
        projectile.Scale = newScale;
    }
}