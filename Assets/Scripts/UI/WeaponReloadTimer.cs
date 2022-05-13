using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponReloadTimer : WeaponUI
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image circle;

    private bool isAppeared = false;
    private ReloadingWeapon weapon;

    public void Init(ReloadingWeapon weapon)
    {
        this.weapon = weapon;
    }

    private void Appear()
    {
        circle.enabled = true;
        text.enabled = true;
        isAppeared = true;
    }

    private void Disappear()
    {
        circle.enabled = false;
        text.enabled = false;
        isAppeared = false;
    }

    private void UpdateValues()
    {
        circle.fillAmount = 1 - weapon.ReloadProgress;
        text.text = ((int)weapon.ReloadLeft).ToString();
    }

    public void Update()
    {
        if (isAppeared && !weapon.IsReloading)
            Disappear();
        else if (!isAppeared && weapon.IsReloading)
            Appear();
        if (isAppeared)
            UpdateValues();
    }
}
