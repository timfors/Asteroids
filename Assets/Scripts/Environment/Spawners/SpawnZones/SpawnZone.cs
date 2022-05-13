using UnityEngine;

public abstract class SpawnZone : MonoBehaviour
{
    public virtual Vector2 GetRandomPos() { throw new System.NotImplementedException(); }
}