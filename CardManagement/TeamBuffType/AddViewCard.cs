using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardManagement.TeamBuffType
{
    public class AddViewCard: TeamBuffCard
    {
        public AddViewCard()
        {
            Count = 3;
        }

        public override int BuffView(GameObject gameObject, int ViewNumber)
        {
            return ViewNumber + 2;
        }
    }
}