using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AFewDragons.DragonSound
{
    [CustomEditor(typeof(SoundProfile))]
    [CanEditMultipleObjects]
    public class SoundProfileEditor : Editor
    {
        private SerializedProperty clipsProperty;
        private SerializedProperty groupProperty;
        private SerializedProperty volumeProperty;
        private SerializedProperty spatialBlendProperty;

        private SerializedProperty minDistanceProperty;
        private SerializedProperty maxDistanceProperty;
        private SerializedProperty volumeBlendProperty;
        private SerializedProperty spreadProperty;

        private bool curveFoldout = false;

        private void OnEnable()
        {
            clipsProperty = serializedObject.FindProperty("Clips");
            groupProperty = serializedObject.FindProperty("Group");
            volumeProperty = serializedObject.FindProperty("Volume");

            minDistanceProperty = serializedObject.FindProperty("MinDistance");
            maxDistanceProperty = serializedObject.FindProperty("MaxDistance");
            spatialBlendProperty = serializedObject.FindProperty("SpatialBlend");
            volumeBlendProperty = serializedObject.FindProperty("VolumeBlend");
            spreadProperty = serializedObject.FindProperty("Spread3dSound");

        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(clipsProperty);
            EditorGUILayout.PropertyField(groupProperty);
            EditorGUILayout.PropertyField(volumeProperty);
            EditorGUILayout.PropertyField(spatialBlendProperty);


            if(spatialBlendProperty.floatValue > 0)
            {
                curveFoldout = EditorGUILayout.Foldout(curveFoldout, "3D Sound Settings");
                if (curveFoldout)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(minDistanceProperty);
                    EditorGUILayout.PropertyField(maxDistanceProperty);

                    Rect volumeRect = new Rect(0, 0, 1, 1);

                    EditorGUILayout.CurveField(volumeBlendProperty, Color.red, volumeRect, new GUIContent("Volume Blend"));
                    EditorGUILayout.PropertyField(spreadProperty);
                    EditorGUI.indentLevel--;
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}