public interface IWeapon
{
    public bool IsShooting { get; }
    public void StartShooting();
    public void Update();
    public void StopShooting();
    public WeaponUI CreateUI();
}