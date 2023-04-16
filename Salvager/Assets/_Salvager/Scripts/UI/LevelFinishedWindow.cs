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

        public void Show(LevelSummary summary)
        {
            moneyEarned.text = summary.MoneyEarned.ToString();
            time.text = TimeSpan.FromSeconds(summary.TimePassed).ToString(@"mm\:ss\:fff");
        }
    }
}
