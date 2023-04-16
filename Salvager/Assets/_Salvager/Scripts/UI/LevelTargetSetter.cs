using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Salvager.Scripts.UI
{
    public class LevelTargetSetter : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_NoParam getLevelTargetNumber;
        [SerializeField]
        private GameEvent_NoParam getReachedTargetNumber;
        [SerializeField]
        private TMP_Text targetData;
        [SerializeField, Tooltip("Use {0}, {1} to set the positions of the data values")]
        private string dataFormat = "{0} / {1}";

        private int numOfTargets = -1;
        private int targetsReached = -1;

        public void SetNumOfTargets(int num) 
        { 
            numOfTargets = num;
            UpdateTargetData();
        }

        public void SetTargetsReached(int num)
        { 
            targetsReached = num;
            UpdateTargetData();
        }

        private void Start()
        {
            if (numOfTargets == -1) getLevelTargetNumber.Raise(this.gameObject);
            if (targetsReached == -1) getReachedTargetNumber.Raise(this.gameObject);
        }

        private void UpdateTargetData()
        {
            targetData.text = string.Format(dataFormat, targetsReached, numOfTargets);
        }
    }
}
