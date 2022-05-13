using UnityEngine;

[CreateAssetMenu(fileName = "LazerProjectile", menuName = "Weapons/Projectile/Lazer", order = 51)]
public class LazerProjectileData : WeaponProjectileData
{
    [Header("Animation")]
    [SerializeField] private AnimationCurve xScale;

    public AnimationCurve ScaleCurve { get => xScale; }
}