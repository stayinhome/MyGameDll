using MyGameDll;
using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CardManagement
{
    public class DamageCard : AbstractCard
    {

        public int Damage = 6;

        public override void BuffImmediately()
        {
           if(Target != null)
            {
                AbstractTeam abstractTeam = Target.GetComponent<AbstractTeam>();
                if (abstractTeam != null)
                {
                    if (abstractTeam.Defent > Damage)
                    {
                        abstractTeam.BaseNumber = (int)(((abstractTeam.Defent - Damage) / (double)abstractTeam.Defent) * abstractTeam.BaseNumber);
                    }
                    else
                    {
                        Destroy(Target);
                    }

                }
            }
        }


    }
}