using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(SpineAspectRatioFitter), true)]
    [CanEditMultipleObjects]
    /// <summary>
    ///   Custom Editor for the AspectRatioFitter component.
    ///   Extend this class to write a custom editor for an AspectRatioFitter-derived component.
    /// </summary>
    public class SpineAspectRatioFitterEditor : SelfControllerEditor
    {
        SerializedProperty m_AspectMode;
        SerializedProperty m_AspectRatio;
        SerializedProperty m_NativeSize;

        protected virtual void OnEnable()
        {
            m_AspectMode = serializedObject.FindProperty("m_AspectMode");
            m_AspectRatio = serializedObject.FindProperty("m_AspectRatio");
            m_NativeSize = serializedObject.FindProperty("m_NativeSize");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_AspectMode);
            EditorGUILayout.PropertyField(m_AspectRatio);
            EditorGUILayout.PropertyField(m_NativeSize);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
