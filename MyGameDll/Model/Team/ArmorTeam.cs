using MyGameDll.Model.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyGameDll.Model.Team
{
    public class ArmorTeam : AbstractTeam
    {
        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 1;
            BaseView = 2;

        }

        protected override int CalDefent()
        {
            return (int)(base.CalDefent() * PropertyValue.ArmorDefentCorrection);
        }

    }
}