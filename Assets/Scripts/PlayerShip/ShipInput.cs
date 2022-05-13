using UnityEngine;

public class ShipInput
{
    private float moveDirection;
    private float rotationDirection;
    private bool isMainWeaponShooting;
    private bool isSecondWeaponShooting;

    public float MoveDirection { get => moveDirection; }
    public float RotationDirection { get => rotationDirection; }
    public bool IsMainWeaponShooting { get => isMainWeaponShooting; }
    public bool IsSecondWeaponShooting { get => isSecondWeaponShooting; }


    public void Update()
    {
        moveDirection = Input.GetAxis("Vertical");
        if (moveDirection < 0)
            moveDirection = 0;
        rotationDirection = -Input.GetAxis("Horizontal");
        isMainWeaponShooting = Input.GetButton("MainWeapon");
        isSecondWeaponShooting = Input.GetButton("SecondWeapon");
    }
}