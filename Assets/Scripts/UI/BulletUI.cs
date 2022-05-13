using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    [SerializeField] private Image filledAmmo;

    private bool isFilled = false;

    public bool IsFilled { get => IsFilled; }

    public void Awake()
    {
        if (isFilled)
            Appear();
        else
            Disappear();

    }

    public void Appear()
    {
        isFilled = true;
        filledAmmo.enabled = true;
    }

    public void SetState(bool state)
    {
        if (state && !isFilled)
            Appear();
        else if (!state && isFilled)
            Disappear();
    }
    public void Disappear()
    {
        isFilled = false;
        filledAmmo.enabled = false;
    }
}