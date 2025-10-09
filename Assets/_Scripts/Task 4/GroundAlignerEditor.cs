using UnityEditor;
using UnityEngine;

namespace DarkGravityGames.Task4
{
    [CustomEditor(typeof(GroundAligner))]
    public class GroundAlignerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GroundAligner groundAligner = (GroundAligner)target;

            GUILayout.Space(15);

            if (GUILayout.Button("Align to Ground"))
            {
                Undo.RecordObject(groundAligner, "Align to Ground");
                groundAligner.AlignObject();

                EditorUtility.SetDirty(groundAligner);
            }
        }
    }
}
