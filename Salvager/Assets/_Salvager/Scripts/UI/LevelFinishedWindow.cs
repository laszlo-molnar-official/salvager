using Assets._Salvager.Scripts.Level;
using Assets.Scripts.Events;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Salvager.Scripts.UI
{
    public class LevelFinishedWindow : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyEarned;
        [SerializeField]
        private TMP_Text time;
        [SerializeField]
        private GameObject window;

        private bool levelFinished;

        public void SetLevelFinished() => levelFinished = true;

        public void Show(LevelSummary summary)
        {
            if (levelFinished)
            { 
                window.SetActive(true);
                moneyEarned.text = summary.MoneyEarned.ToString() +
                    " / " +
                    summary.MaxMoney.ToString();

                time.text = TimeSpan.FromSeconds(summary.TimePassed).ToString(@"mm\:ss\:fff");
            }
        }
    }
}
