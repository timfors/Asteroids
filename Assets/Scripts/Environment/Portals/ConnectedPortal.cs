using UnityEngine;

public class ConnectedPortal : MonoBehaviour, IPortal
{
    [SerializeField] private ConnectedPortal connectedPortal;
    [SerializeField] private Transform portalExit;

    [SerializeField] private bool isTeleportByX;
    [SerializeField] private bool isTeleportByY;

    public Vector3 Exit
    {
        get => portalExit.position;
    }

    public Vector3 GetPos(Vector3 pos)
    {
        Vector3 newPos = pos;
        if (isTeleportByX)
            newPos.x = connectedPortal.Exit.x;
        if (isTeleportByY)
            newPos.y = connectedPortal.Exit.y;

        return newPos;
    }
}