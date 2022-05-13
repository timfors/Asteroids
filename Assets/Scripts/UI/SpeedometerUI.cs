using UnityEngine;
using TMPro;
using System;

public class SpeedometerUI : SessionUI
{
    [SerializeField] private TextMeshProUGUI speedText;

    private float prevValue;

    // Update is called once per frame
    void Update()
    {
        var currentValue = sessionData.PlayerShip.MovementSpeed;

        if (currentValue != prevValue)
        {
            speedText.text = Math.Round(currentValue, 1).ToString();
            prevValue = currentValue;
        }
    }
}
