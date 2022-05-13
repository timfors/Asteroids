using UnityEngine;
using TMPro;

public class AnglesUI : SessionUI
{
    [SerializeField] private TextMeshProUGUI speedText;

    private float prevValue;

    // Update is called once per frame
    void Update()
    {
        float currentValue = sessionData.PlayerShip.EulerAngles.z;

        if (currentValue != prevValue)
        {
            speedText.text = ((int)currentValue).ToString();
            prevValue = currentValue;
        }
    }
}