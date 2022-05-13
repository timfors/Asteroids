public class ShipWeaponLogic
{
    private ShipInput shipInput;
    private IWeapon mainWeapon;
    private IWeapon secondWeapon;

    public ShipWeaponLogic(ShipInput input, IWeapon mainWeapon, IWeapon secondWeapon)
    {
        this.shipInput = input;
        this.mainWeapon = mainWeapon;
        this.secondWeapon = secondWeapon;
    }

    public void UpdateWeaponState(IWeapon weapon, bool buttonState)
    {
        if (!weapon.IsShooting && buttonState)
            weapon.StartShooting();
        else if (weapon.IsShooting && !buttonState)
            weapon.StopShooting();
    }

    public void Update()
    {
        UpdateWeaponState(secondWeapon, shipInput.IsSecondWeaponShooting);
        if (!shipInput.IsSecondWeaponShooting)
            UpdateWeaponState(mainWeapon, shipInput.IsMainWeaponShooting);
        else if (mainWeapon.IsShooting)
            mainWeapon.StopShooting();

        mainWeapon.Update();
        secondWeapon.Update();
    }
}