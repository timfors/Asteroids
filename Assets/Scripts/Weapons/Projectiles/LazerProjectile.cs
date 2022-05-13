using UnityEngine;

public class LazerProjectile : WeaponProjectile, IScaleAdapter
{
    [SerializeField] private LazerProjectileData projectileData;

    private LazerProjectileLogic projectileLogic;

    public Vector3 Scale { get => transform.localScale; set => transform.localScale = value; }

    public void Awake()
    {
        projectileLogic = new LazerProjectileLogic(this, projectileData);
        projectileLogic.OnDestroy += () => Destroy(gameObject);
    }

    public void Update()
    {
        projectileLogic.Update();
    }
}