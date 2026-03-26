using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace MDG
{
    [CustomEditor(typeof(RandomPathGenerator))]
    public class RandomPathGeneratorEditor : Editor
    {
        /*SerializedProperty minPoints;
        SerializedProperty maxPoints;

        void OnEnable()
        {
            // Setup the SerializedProperties.
            minPoints = serializedObject.FindProperty("minPoints");
            maxPoints = serializedObject.FindProperty("maxPoints");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.IntSlider(minPoints, 0, 100, new GUIContent("MinimumPoints"));
            ProgressBar(minPoints.intValue / 100.0f, "MinimumPoints");

            EditorGUILayout.IntSlider(maxPoints, 0, 100, new GUIContent("MaximumPoints"));
            ProgressBar(maxPoints.intValue / 100.0f, "MaximumPoints");
        }

        void ProgressBar(float value, string label)
        {
            // Get a rect for the progress bar using the same margins as a textfield:
            Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rect, value, label);
            EditorGUILayout.Space();
        }

        void DrawDefaultInspector(){

        }*/
    }

}