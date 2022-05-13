using UnityEngine;


public class WeaponProjectileData : ScriptableObject
{
    [SerializeField] private float lifeTime;

    public float LifeTime { get => lifeTime; }
}
