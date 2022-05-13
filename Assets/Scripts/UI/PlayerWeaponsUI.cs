using UnityEngine;

public class PlayerWeaponsUI : SessionUI
{
    [SerializeField] private Transform parentForObjects;
    public override void Init(SessionData sessionData)
    {
        var playerShip = sessionData.PlayerShip;
        var mainWeapon = playerShip.MainWeapon.CreateUI();
        var secondWeapon = playerShip.SecondWeapon.CreateUI();

        if (mainWeapon)
            mainWeapon.transform.parent = parentForObjects;
        if (secondWeapon)
            secondWeapon.transform.parent = parentForObjects;
    }
}
