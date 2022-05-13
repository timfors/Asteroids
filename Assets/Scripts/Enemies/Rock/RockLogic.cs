using UnityEngine;

public class RockLogic : ITeleportable
{
    private Rock rock;
    private RockData data;
    private Vector2 moveDirection;
    private float rotationDirection;

    public event System.Action OnDie;

    public RockLogic(Rock rock, RockData data)
    {
        this.rock = rock;
        this.data = data;
        moveDirection = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
        rotationDirection = Random.Range(-1, 1f) > 0 ? 1 : -1;

        moveDirection.Normalize();
    }

    public void Update()
    {
        rock.Position += (Vector3)moveDirection * Time.deltaTime * data.MovementData.movementSpeed;
        rock.EulerAngles += Vector3.forward * Time.deltaTime * data.MovementData.rotationSpeed * rotationDirection;
    }

    public void Teleport(IPortal portal)
    {
        rock.Position = portal.GetPos(rock.Position);
    }

    public void Hit(Collider2D collision)
    {
        if (collision.TryGetComponent<IPortal>(out var portal))
            Teleport(portal);
        if (collision.TryGetComponent<WeaponProjectile>(out var projectile))
            OnDie();
    }

}