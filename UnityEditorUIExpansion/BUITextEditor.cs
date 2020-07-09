using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(BUIText), true)]
    [CanEditMultipleObjects]
    /// <summary>
    ///   Custom Editor for the Text Component.
    ///   Extend this class to write a custom editor for an Text-derived component.
    /// </summary>
    public class BlitzTextEditor : GraphicEditor
    {
        SerializedProperty m_Text;
        SerializedProperty m_FontData;
        //SerializedProperty m_OutLine;
        //SerializedProperty m_OutLineColor;
        //SerializedProperty m_OutLineOffsetX;
        //SerializedProperty m_OutLineOffsetY;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Text = serializedObject.FindProperty("m_Text");
            m_FontData = serializedObject.FindProperty("m_FontData");
            //m_OutLine = serializedObject.FindProperty("m_OutLine");
            //m_OutLineColor = serializedObject.FindProperty("m_OutLineColor");
            //m_OutLineOffsetX = serializedObject.FindProperty("m_OutLineOffsetX");
            //m_OutLineOffsetY = serializedObject.FindProperty("m_OutLineOffsetY");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_Text);
            EditorGUILayout.PropertyField(m_FontData);
            //EditorGUILayout.PropertyField(m_OutLine);
            //EditorGUILayout.PropertyField(m_OutLineColor);
            //EditorGUILayout.PropertyField(m_OutLineOffsetX);
            //EditorGUILayout.PropertyField(m_OutLineOffsetY);
            AppearanceControlsGUI();
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
