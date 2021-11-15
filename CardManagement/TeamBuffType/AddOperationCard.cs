using MyGameDll;
using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardManagement.TeamBuffType
{
    public class AddOperationCard : TeamBuffCard
    {

        public override void BuffImmediately()
        {
            if(Target != null)
            {
                AbstractTeam abstractTeam = Target.GetComponent<AbstractTeam>();
                if(abstractTeam != null)
                {
                    abstractTeam.Operater = abstractTeam._Operater + 1;
                }
            }

        }


    }
}