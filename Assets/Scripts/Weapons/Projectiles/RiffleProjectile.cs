using UnityEngine;

public class RiffleProjectile : WeaponProjectile, IPositionAdapter
{
    [SerializeField] private RiffleProjectileData projectileData;
    private RiffleProjectileLogic projectileLogic;

    public void Awake()
    {
        transform.parent = null;
        projectileLogic = new RiffleProjectileLogic(this, projectileData, transform.up);
        projectileLogic.OnDestroy += () => Destroy(gameObject);
    }

    public Vector3 Position 
    {
        get => transform.position;
        set => transform.position = value;
    }

    public void FixedUpdate()
    {
        projectileLogic.FixedUpdate();
    }

    public void Update()
    {
        projectileLogic.Update();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        projectileLogic.Hit(collision);
    }
}