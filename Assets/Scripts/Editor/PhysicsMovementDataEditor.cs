using UnityEditor;
using UnityEngine;

public class PhysicsMovementDataEditor
{
    public static void DrawFields(SerializedObject serialized)
    {
        var moveSpeedScale = serialized.FindProperty("moveVelocityScale");
        var maxMoveSpeed = serialized.FindProperty("maxMoveSpeed");
        var rotationVelocityScale = serialized.FindProperty("rotationVelocityScale");
        var maxRotationSpeed = serialized.FindProperty("maxRotationSpeed");

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Physics Movement Data", EditorStyles.boldLabel);

        EditorPatterns.DrawVectorField("Movement Speed Scale", moveSpeedScale);
        EditorPatterns.DrawVectorField("Max Movement Speed", maxMoveSpeed);
        EditorPatterns.DrawDigitField("Rotation Speed Scale", rotationVelocityScale);
        EditorPatterns.DrawDigitField("Max Rotation Speed", maxRotationSpeed);

        serialized.ApplyModifiedProperties();
        EditorUtility.SetDirty(serialized.targetObject);
    }

    public static void DrawFields(ref PhysicsMovementData data)
    {
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Physics Movement Data", EditorStyles.boldLabel);

        data.moveVelocityScale = EditorPatterns.DrawVectorField("Move Velocity Scale", data.moveVelocityScale);
        data.maxMoveSpeed = EditorPatterns.DrawVectorField("Max Move Speed", data.maxMoveSpeed);

        data.rotationVelocityScale = EditorPatterns.DrawFloatField("Rotation Velocity Scale", data.rotationVelocityScale);
        data.maxRotationSpeed = EditorPatterns.DrawFloatField("Max Rotation Speed", data.maxRotationSpeed);
    }
}