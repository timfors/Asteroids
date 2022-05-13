using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RiffleProjectileData))]
public class RiffleProjectileDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var target = (RiffleProjectileData)serializedObject.targetObject;

        base.OnInspectorGUI();

        MovementDataEditor.DrawFields(ref target.MovementData);
        EditorUtility.SetDirty(target);
        serializedObject.ApplyModifiedProperties();
    }
}
