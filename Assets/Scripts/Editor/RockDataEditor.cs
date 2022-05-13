using UnityEditor;

[CustomEditor(typeof(RockData))]
public class RockDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var target = (RockData)serializedObject.targetObject;

        base.OnInspectorGUI();

        MovementDataEditor.DrawFields(ref target.MovementData);
        EditorUtility.SetDirty(target);
        serializedObject.ApplyModifiedProperties();
    }
}