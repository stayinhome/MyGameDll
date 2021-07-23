using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyGameDll.Model.Dto;

namespace MyGameDll.Model.Team
{
    public class ManeuverTeam : AbstractTeam
    {
        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 3;
            BaseView = 2;

        }

        protected override int CalAttack()
        {
            return (int)(base.CalAttack() * PropertyValue.ManeuverAttackCorrection);
        }

        protected override int CalDefent()
        {
            return (int)(base.CalDefent() * PropertyValue.ManeuverDefentCorrection);
        }
    }
}