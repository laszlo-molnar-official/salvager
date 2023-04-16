using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Salvager.Scripts.Level
{
    [Serializable]
    public class LevelSummary
    {
        public int MaxMoney;
        public int MoneyEarned;
        public float TimeBeforeMoneyLessens;
        public float TimeWhenMoneyLessens;
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
