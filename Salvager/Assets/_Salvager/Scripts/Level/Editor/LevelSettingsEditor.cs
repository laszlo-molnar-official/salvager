using Pinwheel.Poseidon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
