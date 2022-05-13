using UnityEditor;

[CustomEditor(typeof(EnemyShipData))]
public class EnemyShipDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var target = (EnemyShipData)serializedObject.targetObject;

        base.OnInspectorGUI();

        PhysicsMovementDataEditor.DrawFields(ref target.MovementData);
        EditorUtility.SetDirty(target);
        serializedObject.ApplyModifiedProperties();
    }
}
