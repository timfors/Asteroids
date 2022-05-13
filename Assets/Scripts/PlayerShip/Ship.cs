using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, ILocalPositionAdatper, IPositionAdapter, IEulerAnglesAdapter
{
    private IWeapon mainWeapon;
    private IWeapon secondWeapon;

    private PhysicsMovementSimulation shipMovement;
    private ShipMovementLogic logic;

    private ShipInput shipInput;

    private ShipWeaponLogic weaponLogic;

    [SerializeField] private ShipData shipData;

    public Vector3 EulerAngles
    {
        get => transform.eulerAngles;
        set => transform.eulerAngles = value;
    }

    public Vector3 LocalPosition
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public IWeapon MainWeapon { get => mainWeapon; }
    public IWeapon SecondWeapon { get => secondWeapon; }

    public ShipMovementLogic Logic { get => logic; }

    public float MovementSpeed
    {
        get => logic.MovenentVelocity.magnitude;
    }

    public void Awake()
    {
        mainWeapon = new SingleShootWeapon(shipData.MainWeapon, transform);
        secondWeapon = new ReloadingWeapon((ReloadingWeaponData)shipData.SecondWeapon, transform);

        shipInput = new ShipInput();

        shipMovement = new PhysicsMovementSimulation(shipData.MovementData);
        logic = new ShipMovementLogic(this, shipMovement, shipInput);
        logic.OnDie += () => gameObject.SetActive(false);

        weaponLogic = new ShipWeaponLogic(shipInput, mainWeapon, secondWeapon);
    }

    private void FixedUpdate()
    {
        logic.FixedUpdate();
    }

    private void Update()
    {
        shipInput.Update();
        weaponLogic.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.Hit(collision);
    }
}
