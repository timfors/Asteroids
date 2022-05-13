using UnityEngine;
using UnityEditor;

public class EditorPatterns
{
    public static void DrawVectorField(string fieldName, SerializedProperty property)
    {
        EditorGUILayout.LabelField(fieldName);
        EditorGUILayout.PropertyField(property, GUIContent.none);
    }

    public static void DrawDigitField(string fieldName, SerializedProperty property)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(fieldName);
        EditorGUILayout.PropertyField(property, GUIContent.none);
        EditorGUILayout.EndHorizontal();
    }

    public static float DrawFloatField(string fieldName, float input)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(fieldName);
        float result = EditorGUILayout.FloatField(input);
        EditorGUILayout.EndHorizontal();

        return result;
    }

    public static Vector2 DrawVectorField(string fieldName, Vector2 input)
    {
        return EditorGUILayout.Vector2Field(fieldName, input);
    }
}