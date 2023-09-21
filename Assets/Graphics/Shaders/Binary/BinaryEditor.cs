// KinoBinary - Binary image effect for Unity
// https://github.com/keijiro/KinoBinary
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Kino
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Binary2))]
    public sealed class BinaryEditor : Editor
    {
        SerializedProperty _ditherType;
        SerializedProperty _ditherScale;
        SerializedProperty _color0;
        SerializedProperty _color1;
        SerializedProperty _opacity;

        static class Styles
        {
            public static readonly GUIContent color0 = new GUIContent("Color (dark)");
            public static readonly GUIContent color1 = new GUIContent("Color (light)");
        }

        void OnEnable()
        {
            _ditherType = serializedObject.FindProperty("_DitherType");
            _ditherScale = serializedObject.FindProperty("_DitherScale");
            _color0 = serializedObject.FindProperty("_Color0");
            _color1 = serializedObject.FindProperty("_Color1");
            _opacity = serializedObject.FindProperty("_Opacity");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_ditherType);
            EditorGUILayout.PropertyField(_ditherScale);
            EditorGUILayout.PropertyField(_color0, Styles.color0);
            EditorGUILayout.PropertyField(_color1, Styles.color1);
            EditorGUILayout.PropertyField(_opacity);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif