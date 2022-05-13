using System.Collections.Generic;
using UnityEngine;

public class SessionUIManager : MonoBehaviour
{
    [SerializeField] private SessionUI[] startSessionInterface;

    private List<SessionUI> sessionUIList = new List<SessionUI>();

    public void Init(SessionData sessionInfo)
    {
        foreach (var prefab in startSessionInterface)
        {
            CreateInterface(prefab, sessionInfo);
        }
    }

    public void CreateInterface(SessionUI prefabUI, SessionData sessionInfo)
    {
        var ui = Instantiate<SessionUI>(prefabUI, transform);
        ui.Init(sessionInfo);
        sessionUIList.Add(ui);
    }
}