using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardManagement.TeamBuffType
{
    public class DoubleDamageCard :TeamBuffCard
    {
        public DoubleDamageCard()
        {
            Count = 3;
        }

        public override int BuffAttack(GameObject gameObject, int AttackNumber)
        {
            return AttackNumber * 2;
        }


    }
}