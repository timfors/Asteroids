using UnityEngine;
using TMPro;

public class CoordinatesUI : SessionUI
{
    [SerializeField] private TextMeshProUGUI speedText;

    private Vector2 prevValue;

    // Update is called once per frame
    void Update()
    {
        Vector2 currentValue = sessionData.PlayerShip.transform.localPosition;

        if (currentValue != prevValue)
        {
            speedText.text = currentValue.ToString();
            prevValue = currentValue;
        }
    }
}
