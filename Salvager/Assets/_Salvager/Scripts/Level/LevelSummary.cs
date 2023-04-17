using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    [Serializable]
    public class LevelSummary
    {
        public int MaxMoney;
        public float TimeBeforeMoneyLessens;
        public float TimeWhenMoneyLessens;
        [HideInInspector]
        public int MoneyEarned;
        [HideInInspector]
        public float TimePassed;

        public void UpdateStats(float deltaTime)
        { 
            TimePassed += deltaTime;
            
            if (TimePassed > TimeBeforeMoneyLessens)
            {
                float time = TimePassed - TimeBeforeMoneyLessens;
                MoneyEarned = (int)MathF.Max(0,
                    (float)Math.Round(MaxMoney * (1 - time / TimeWhenMoneyLessens)));
            }
        }
    }
}
