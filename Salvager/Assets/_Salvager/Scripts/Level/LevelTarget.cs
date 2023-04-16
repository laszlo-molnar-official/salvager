using System;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    [Serializable]
    public class LevelTarget : MonoBehaviour
    {
        [SerializeField, Tooltip("ID is used to identify this type of target. " +
            "Set it in the prefab.")]
        private int id = -1;

        public int ID { get { return id; } private set { id = value; } }
    }
}