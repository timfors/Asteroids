using UnityEngine;

public class SessionUI : MonoBehaviour
{
    protected SessionData sessionData;

    public virtual void Init(SessionData data)
    {
        sessionData = data;
    }
}
