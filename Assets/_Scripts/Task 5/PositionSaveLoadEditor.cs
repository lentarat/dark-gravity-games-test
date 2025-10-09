using UnityEditor;
using UnityEngine;

namespace DarkGravityGames.Task5
{
    [CustomEditor(typeof(PositionsSaveLoad))]
    public class PositionSaveLoadEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PositionsSaveLoad positionSaveLoad = (PositionsSaveLoad)target;

            GUILayout.Space(15);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Save Position"))
            {
                Undo.RecordObject(positionSaveLoad.transform, "Save Position");
                positionSaveLoad.Save();
                EditorUtility.SetDirty(positionSaveLoad);
            }

            if (GUILayout.Button("Load Position"))
            {
                Undo.RecordObject(positionSaveLoad.transform, "Load Position");
                positionSaveLoad.Load();
                EditorUtility.SetDirty(positionSaveLoad);
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}