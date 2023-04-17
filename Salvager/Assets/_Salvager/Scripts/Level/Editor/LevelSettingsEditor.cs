#if UNITY_EDITOR
using Pinwheel.Poseidon;
using UnityEditor;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    [CustomEditor(typeof(LevelSettings))]
    public class LevelSettingsEditor : Editor
    {
    
        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            if (GUILayout.Button("Collect and Setup Targets"))
            {
                var water = FindObjectOfType<PWater>();
                ((LevelSettings)target).SetTargets(FindObjectsOfType<LevelTarget>(), water);
                EditorUtility.SetDirty(target);
            }
        }
    }
}
#endif // UNITY_EDITOR