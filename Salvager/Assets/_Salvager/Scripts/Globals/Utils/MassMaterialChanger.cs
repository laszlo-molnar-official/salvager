#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Globals.Utils
{
    [Serializable]
    public class Materials
    {
        public Material OldMaterial;
        public Material NewMaterial;
    }

    public class MassMaterialChanger : MonoBehaviour
    {
        public List<Materials> MaterialList;
        public Transform RootObject;

        [ContextMenu("Change Materials")]
        public void ChangeMaterial()
        { 
            var objs = RootObject.GetComponentsInChildren<MeshRenderer>();
            Debug.Log("MassMaterialChanger::ChangeMaterial: starting, found " + objs.Length);

            for (int i = 0; i < objs.Length; ++i)
            {
                var obj = objs[i];
                var matPair = MaterialList.Find(x => x.OldMaterial.name == obj.sharedMaterial.name);

                if (matPair != null)
                {
                    obj.sharedMaterial = matPair.NewMaterial;
                    EditorUtility.SetDirty(obj.gameObject);
                    Debug.Log("MassMaterialChanger::ChangeMaterial: changed: " + obj.gameObject.name);
                }
            }
        }
    }
}
#endif // UNITY_EDITOR