using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameDll.Model.Dto;

namespace MyGameDll.Team
{
    class ChessGun : AbstractTeam
    {

        public override void RefreshMe()
        {
            base.RefreshMe();
            Operater = 2;
        }

        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 2;
            TeamType = TeamEnum.ChessGun;


        }

    }
}
