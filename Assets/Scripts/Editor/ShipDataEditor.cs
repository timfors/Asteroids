using UnityEditor;

[CustomEditor(typeof(ShipData))]
public class ShipDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var target = (ShipData)serializedObject.targetObject;
        
        base.OnInspectorGUI();

        PhysicsMovementDataEditor.DrawFields(ref target.MovementData);
        EditorUtility.SetDirty(target);
        serializedObject.ApplyModifiedProperties();
    }
}
