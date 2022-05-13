using UnityEngine;
using UnityEditor;

public class MovementDataEditor
{
    public static void DrawFields(SerializedObject serialized)
    {
        var movementSpeed = serialized.FindProperty("movementSpeed");
        var rotationSpeed = serialized.FindProperty("rotationSpeed");

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Movement Data", EditorStyles.boldLabel);

        EditorPatterns.DrawDigitField("Movement Speed", movementSpeed);
        EditorPatterns.DrawDigitField("Rotation Speed", rotationSpeed);

        serialized.ApplyModifiedProperties();
        EditorUtility.SetDirty(serialized.targetObject);
    }

    public static void DrawFields(ref MovementData data)
    {
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Movement Data", EditorStyles.boldLabel);

        data.movementSpeed = EditorPatterns.DrawFloatField("Movement Speed", data.movementSpeed);
        data.rotationSpeed = EditorPatterns.DrawFloatField("Rotation Speed", data.rotationSpeed);
    }
}
