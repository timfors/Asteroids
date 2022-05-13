using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoxSpawnZone : SpawnZone
{
    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public override Vector2 GetRandomPos()
    {
        Vector2 middlePoint = (Vector2)transform.position + collider.offset;
        Vector2 indent;
        float r = transform.eulerAngles.z * Mathf.Deg2Rad;

        indent.x = Random.Range(-collider.size.x, collider.size.x) * transform.lossyScale.x / 2;
        indent.y = Random.Range(-collider.size.y, collider.size.y) * transform.lossyScale.y / 2;

        Vector2 rotatedIndent;
        
        rotatedIndent.x = indent.x * Mathf.Cos(r) + indent.y * Mathf.Sin(r);
        rotatedIndent.y = indent.y * Mathf.Cos(r) + indent.x * Mathf.Sin(r);

        return middlePoint + rotatedIndent;
    }
}
