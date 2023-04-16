using Assets._Salvager.Scripts.Level;
using Assets.Scripts.Events;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Salvager.Scripts.UI
{
    public class LevelSummaryUI : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_NoParam getLevelSummaryRef;
        [SerializeField]
        private TMP_Text moneyEarned;
        [SerializeField]
        private TMP_Text time;

        private LevelSummary summaryRef;

        public void SetLevelSummary(LevelSummary summary) => summaryRef = summary;

        private void Start()
        {
            if (summaryRef == null) getLevelSummaryRef.Raise(this.gameObject);
        }

        private void Update()
        {
            if (summaryRef != null)
            {
                moneyEarned.text = summaryRef.MoneyEarned.ToString();
                UpdateTime();
            }
        }

        private void UpdateTime()
        {
            if (summaryRef.TimePassed < summaryRef.TimeBeforeMoneyLessens)
            {
                float timeRemaining = summaryRef.TimeBeforeMoneyLessens - summaryRef.TimePassed;
                time.text = (timeRemaining > 60 ? "" : "<color=red>") + TimeSpan.
                    FromSeconds(timeRemaining).
                    ToString(@"mm\:ss") + (timeRemaining > 60 ? "" : "</color>");
            }
            else
            {
                time.text = TimeSpan.
                    FromSeconds(summaryRef.TimePassed - summaryRef.TimeBeforeMoneyLessens).
                    ToString(@"mm\:ss");                
            }
        }
    }
}
