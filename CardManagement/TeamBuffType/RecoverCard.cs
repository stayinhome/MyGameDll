using MyGameDll;
using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CardManagement.TeamBuffType
{
    public class RecoverCard :TeamBuffCard
    {
        public override void BuffImmediately()
        {
            if (Target != null)
            {
                AbstractTeam abstractTeam = Target.GetComponent<AbstractTeam>();
                if (abstractTeam != null)
                {
                    abstractTeam.BaseNumber = abstractTeam.IniBaseNumber;
                }
            }

        }

    }
}